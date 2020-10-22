using Core.Dtos;
using Core.Models;
using Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Auth;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository repository;
        private readonly ICurrentRequestDataProvider currentRequestDataProvider;
        public OrderService(IRepository repository, ICurrentRequestDataProvider currentRequestDataProvider)
        {
            this.repository = repository;
            this.currentRequestDataProvider = currentRequestDataProvider;
             
        }

        public async Task<List<Order>> GetMyOrders()
        {
            var currentCustomer = await currentRequestDataProvider.GetCurrentRequestCustomer();
            return await this.repository.GetQuery<Order>(_ => _.CustomerId == currentCustomer.Id).ToListAsync();
        }

        public async Task<long> PayTheOrder(OrderPaymentRequest orderPaymentRequest)
        {
            var order = await this.repository.Get<Order>(_ => _.Id == orderPaymentRequest.OrderId);
            var orderPayment = new OrderPayment()
            {
                OrderId = orderPaymentRequest.OrderId,
                Amount = orderPaymentRequest.Amount,
                PaymentMethod = orderPaymentRequest.PaymentMethod,
                PaymentTime = DateTime.UtcNow
            };
            order.PaidAmount += orderPayment.Amount;
            order.OrderStatusId = (order.TotalPayable - order.PaidAmount) < 0.001M ? (short)OrderStatuses.Paid : (short)OrderStatuses.Pending;

            await repository.Insert<OrderPayment>(orderPayment);
            await repository.Save();

            return order.Id;
        }

        public async Task<long> PlaceOrder(OrderRequest orderRequest)
        {
            var currentCustomer = await currentRequestDataProvider.GetCurrentRequestCustomer();

            var products = await this.repository.GetQuery<Product>(_ => orderRequest.ProductIds.Contains(_.Id)).ToListAsync();

            List<OrderItem> orderItems = products.Select(_ => new OrderItem() { ProductId = _.Id, Price = _.Price }).ToList();
            var totalPrice = orderItems.Sum(_ => _.Price);
            var totalDiscountPercentage = 0;
            var order = new Order()
            {
                CustomerId = currentCustomer.Id,
                OrderItems = orderItems,
                OrderStatusId = (short)OrderStatuses.Pending,
                TotalPrice = totalPrice,
                Discount = totalDiscountPercentage,
                TotalPayable = totalPrice - (totalPrice * totalDiscountPercentage / 100.0m),
                UpdatedTime = DateTime.UtcNow,
                PaidAmount = 0.0M
            };

            await this.repository.Insert<Order>(order);
            await this.repository.Save();
            return order.Id;
        }
    }
}
