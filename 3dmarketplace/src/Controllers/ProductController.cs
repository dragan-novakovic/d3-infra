using Microsoft.AspNetCore.Mvc;
using _3dmarketplace.src.Models;
using _3dmarketplace.src.Services;

namespace _3dmarketplace.src.Controllers
{


    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        public required ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

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
        public async Task<ActionResult> Create([FromBody] Product product)
        {

            if (product == null)
            {
                return BadRequest();
            }

            await _productService.Create(product);
            return Ok();
        }

    }

}
