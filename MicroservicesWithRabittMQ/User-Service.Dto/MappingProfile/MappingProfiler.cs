using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Service.Core;
using User_Service.Dto.DTOs;

namespace User_Service.Dto.MappingProfile
{
    public class MappingProfiler : Profile
    {
        public MappingProfiler()
        {
            CreateMap<User, UserGetDto>().ReverseMap();
            CreateMap<User, UserCreateDto>().ReverseMap();
        }
    }
}
