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
        public async Task<ActionResult> Create([FromBody] ProductDto product_dto)
        {

            if (product_dto == null)
            {
                return BadRequest();
            }


            var product = new Product
            {
                Name = product_dto.Name,
                Price = product_dto.Price,
                Description = product_dto.Description,
                Stock = product_dto.Stock,
                UserId = product_dto.UserId,
                CategoryId = product_dto.CategoryId
            };

            await _productService.Create(product);
            return Ok();
        }

    }

}
