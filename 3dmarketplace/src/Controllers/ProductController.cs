using Microsoft.AspNetCore.Mvc;
using _3dmarketplace.src.Models;

namespace _3dmarketplace.src.Controllers
{


    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        private static readonly List<Product> _products = new()
        {
        new Product { Name = "Product 1", Price = 100, Description = "Description 1" },
        new Product { Name = "Product 2", Price = 200, Description = "Description 2" },
        new Product { Name = "Product 3", Price = 300, Description = "Description 3" },
        new Product { Name = "Product 4", Price = 400, Description = "Description 4" },
        new Product { Name = "Product 5", Price = 500, Description = "Description 5" }
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_products);
        }


        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            _products.Add(product);
            return Ok();
        }

    }

}
