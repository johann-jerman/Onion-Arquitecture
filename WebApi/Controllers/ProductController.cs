using Application.DTO;
using Application.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly ProductService _prodcuctService;

        public ProductController(ProductService productService)
        {
            this._prodcuctService= productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                return Ok(_prodcuctService.GetAll());
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult ById(int id)
        {
            try
            {
                return Ok(_prodcuctService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductDTO productDTO) 
        {
            try
            {
                return Ok(_prodcuctService.Create(productDTO));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProductDTO productDTO)
        {
            try
            {
                return Ok(_prodcuctService.Update(productDTO, id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _prodcuctService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
