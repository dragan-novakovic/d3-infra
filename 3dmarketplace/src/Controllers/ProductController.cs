using Microsoft.AspNetCore.Mvc;

namespace _3dmarketplace.src.Controllers
{


    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Product Index");
        }
    }

}