using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Order_Service.Core;
using Order_Service.Dto.DTOs;
using Order_Service.Infrastructure.Context;
using Order_Service.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Service.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public OrderService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<OrderCreateDto> CreateOrderAsync(OrderCreateDto orderCreateDto)
        {
            try
            {
                var order = _mapper.Map<Order>(orderCreateDto);
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
                return orderCreateDto;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<OrderGetDto>?> GetAllOrdersAsync()
        {
            List<OrderGetDto>? orders = null;
            var queryResult = _context.Orders.AsQueryable();
            if (queryResult.Count() > 0)
            {
                var filterOrders = await queryResult.ToListAsync();
                orders = _mapper.Map<List<OrderGetDto>>(filterOrders);
                return orders;
            }
            return orders;
        }

        public async Task<OrderGetDto?> GetOrderByIdAsync(int Id)
        {
            OrderGetDto? order = null;
            var queryResult = _context.Orders.Where(x => x.Id == Id).AsQueryable();
            if (queryResult.Count() > 0)
            {
                var filterOrder = await queryResult.FirstOrDefaultAsync();
                order = _mapper.Map<OrderGetDto>(filterOrder);
                return order;
            }
            return order;
        }
    }
}
