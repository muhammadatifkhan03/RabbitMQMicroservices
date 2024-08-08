using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Service.Dto.DTOs;

namespace User_Service.Infra.Interfaces
{
    public interface IUserService
    {
        Task<UserCreateDto> CreateUserAsync(UserCreateDto userCreateDto);
        Task<List<UserGetDto>?> GetAllUsersAsync();
        Task<UserGetDto?> GetUserByIdAsync(int Id);
    }
}
