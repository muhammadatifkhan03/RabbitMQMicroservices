using AutoMapper;
using Order_Service.Core;
using Order_Service.Dto.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Service.Dto.MappingProfile
{
    public class MappingProfiler : Profile
    {
        public MappingProfiler()
        {
            CreateMap<Order, OrderCreateDto>().ReverseMap();
            CreateMap<Order, OrderGetDto>().ReverseMap();
        }
    }
}
