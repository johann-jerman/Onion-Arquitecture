using Application.DTO;
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
                return Ok(orderService.Get());
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
                return Ok(orderService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };
        }

        [HttpPost]
        public IActionResult Create([FromBody] OrderDTO order)
        {
            try
            {
                return Ok(orderService.Create(order));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] OrderDTO order ,int id)
        {
            try
            {
                return Ok(orderService.Update(order, id));
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
                orderService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };
        }
    }
}
