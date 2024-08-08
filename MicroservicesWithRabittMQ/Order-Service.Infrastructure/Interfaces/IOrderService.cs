using Order_Service.Dto.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Service.Infrastructure.Interfaces
{
    public interface IOrderService
    {
        Task<OrderCreateDto> CreateOrderAsync(OrderCreateDto orderCreateDto);
        Task<List<OrderGetDto>?> GetAllOrdersAsync();
        Task<OrderGetDto?> GetOrderByIdAsync(int Id);
    }
}
