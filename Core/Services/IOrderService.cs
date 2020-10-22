using Core.Dtos;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IOrderService
    {
        Task<long> PlaceOrder(OrderRequest orderRequest);
        Task<List<Order>> GetMyOrders();
        Task<long> PayTheOrder(OrderPaymentRequest orderPaymentRequest);
    }
}
