using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Dtos;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyOrders()
        {
            var orderId = await orderService.GetMyOrders();
            return Ok(orderId);
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(OrderRequest orderRequest)
        {
            var orderId = await orderService.PlaceOrder(orderRequest);
            return Ok(orderId);
        }

        [HttpPost]
        [Route("payment")]
        public async Task<IActionResult> PayTheOrder(OrderPaymentRequest orderPaymentRequest)
        {
            var orderId = await orderService.PayTheOrder(orderPaymentRequest);
            return Ok(orderId);
        }
    }
}