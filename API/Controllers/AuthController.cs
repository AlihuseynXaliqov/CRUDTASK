using Business.DTOs.Auth;
using Business.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            try
            {
                await _userService.RegisterAsync(dto);
                return Ok();

            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
        [HttpPost("[Action]")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            try
            {
               
                return Ok(await _userService.LoginAsync(dto));
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

        }
    }
}
