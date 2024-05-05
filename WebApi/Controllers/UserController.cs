using Application.DTO;
using Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService) 
        {
            _userService = userService;
        }

        [HttpGet("{email}")]
        public IActionResult ById(string email)
        {
            try
            {
                return Ok(_userService.GetByEmail(email));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserDTO user)
        {
            try
            {
                return Ok(_userService.Create(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] UserDTO user ,int id)
        {
            try
            {
                return Ok(_userService.Update(user, id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _userService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };
        }
    }
}
