using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{id}")]
        public IActionResult ById(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id)
        {
            return View();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}
