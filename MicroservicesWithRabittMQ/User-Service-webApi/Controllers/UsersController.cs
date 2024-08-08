using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User_Service.Dto.DTOs;
using User_Service.Infra.Interfaces;

namespace User_Service_webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("/CreateUser")]
        public async Task<IActionResult> CreateUser(UserCreateDto userCreateDto)
        {
            var result = await _userService.CreateUserAsync(userCreateDto);
            return Ok(result);
        }

        [HttpGet]
        [Route("/GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userService.GetAllUsersAsync();
            if (result is null)
                return NotFound("Not Found.");
            return Ok(result);
        }

        [HttpGet]
        [Route("/GetUserById")]
        public async Task<IActionResult> GetUserById(int Id)
        {
            var result = await _userService.GetUserByIdAsync(Id);
            if (result is null)
                return NotFound("Not Found.");
            return Ok(result);
        }

    }
}
