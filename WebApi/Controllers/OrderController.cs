using Application.DTO;
using Application.Service;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly OrderService orderService;
        private readonly OrderProductService orderProductService;

        public OrderController(OrderService orderService, OrderProductService orderProductService) 
        {
            this.orderService = orderService;
            this.orderProductService = orderProductService;
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

        [HttpPost("add-product")]
        public IActionResult AddProduct([FromBody] OrderProductDTO orderProduct) 
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                Order order = orderProductService.AddProduct(orderProduct);
                string serializedOrder = JsonSerializer.Serialize(order, options);
                return Ok(order);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-product/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                orderProductService.DeleteProduct(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
