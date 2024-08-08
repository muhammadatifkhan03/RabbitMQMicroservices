using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Service.Core;
using User_Service.Dto.DTOs;
using User_Service.Infra.Context;
using User_Service.Infra.Interfaces;

namespace User_Service.Infra.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UserService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserCreateDto> CreateUserAsync(UserCreateDto userCreateDto)
        {
            try
            {
                var user = _mapper.Map<User>(userCreateDto);
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return userCreateDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<UserGetDto>?> GetAllUsersAsync()
        {
            List<UserGetDto>? users = null;
            var queryResult = _context.Users.AsQueryable();
            if (queryResult.Count() > 0)
            {
                var filterUsers = await queryResult.ToListAsync();
                users = _mapper.Map<List<UserGetDto>>(filterUsers);
                return users;
            }
            return users;
        }

        public async Task<UserGetDto?> GetUserByIdAsync(int Id)
        {
            UserGetDto? user = null;
            var queryResult = _context.Users.Where(x => x.Id == Id).AsQueryable();
            if (queryResult.Count() > 0)
            {
                var filterUsers = await queryResult.FirstOrDefaultAsync();
                user = _mapper.Map<UserGetDto>(filterUsers);
                return user;
            }
            return user;
        }
    }
}
