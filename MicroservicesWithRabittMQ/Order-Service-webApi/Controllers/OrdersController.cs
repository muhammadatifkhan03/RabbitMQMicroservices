using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order_Service.Dto.DTOs;
using Order_Service.Infrastructure.Interfaces;

namespace Order_Service_webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IRabbitMQProducer _rabbitMQProducer;
        public OrdersController(IOrderService orderService, IRabbitMQProducer rabbitMQProducer)
        {
            _orderService = orderService;
            _rabbitMQProducer = rabbitMQProducer;
        }

        [HttpPost]
        [Route("/CreateOrder")]
        public async Task<IActionResult> CreateOrder(OrderCreateDto orderCreateDto)
        {
            var result = await _orderService.CreateOrderAsync(orderCreateDto);
            _rabbitMQProducer.SendProductMessage(orderCreateDto);
            return Ok(result);
        }

        [HttpGet]
        [Route("/GetAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var result = await _orderService.GetAllOrdersAsync();
            if (result is null)
                return NotFound("Not Found.");
            return Ok(result);
        }

        [HttpGet]
        [Route("/GetOrderById/{Id}")]
        public async Task<IActionResult> GetOrderById(int Id)
        {
            var result = await _orderService.GetOrderByIdAsync(Id);
            if (result is null)
                return NotFound("Not Found.");
            return Ok(result);
        }
    }
}
