using Application.DTO;
using Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly AuthService _authService;
        private readonly UserService _userService;

        public AuthController(AuthService authService, UserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserDTO user)
        {
            try
            {
                //validate user existence
                _userService.GetByEmail(user.Email);
                return Ok(_authService.Login(user));
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            return View();
        }
    }
}
