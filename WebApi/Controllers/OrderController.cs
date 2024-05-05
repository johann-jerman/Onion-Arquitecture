using Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly OrderService orderService;

        public OrderController(OrderService orderService) 
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                return Ok(orderService);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };
        }

        [HttpGet("{id}")]
        public IActionResult ById(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };
        }

        [HttpPost]
        public IActionResult Create()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id)
        {
            try
            {
                return Ok();
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
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };
        }
    }
}
