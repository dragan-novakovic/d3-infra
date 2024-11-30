using Microsoft.AspNetCore.Mvc;
using _3dmarketplace.src.Models;

namespace _3dmarketplace.src.Controllers
{


    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        private static readonly List<Product> _products = [];

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_products);
        }


        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            return NotFound();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            _products.Add(product);
            return Ok();
        }

    }

}
