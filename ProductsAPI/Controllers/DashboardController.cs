using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Repositories;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var productRepository = new ProductRepository();
            var result = productRepository.GroupByCategory();

            return Ok(result);
        }
    }
}
