using Application.DTO;
using Application.Service;
//using Application.SwaggerExamples;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            this._categoryService = categoryService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                return Ok(this._categoryService.GetAll());
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult ById(int id) 
        {
            try
            {
                return Ok(this._categoryService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] CategoryDTO category) 
        {
            try
            {
                return Ok(this._categoryService.Create(category));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] CategoryDTO category, int id)
        {
            try
            {
                return Ok(this._categoryService.Update(category, id));
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
                this._categoryService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
