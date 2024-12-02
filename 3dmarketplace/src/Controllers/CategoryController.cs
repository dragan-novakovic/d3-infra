using Microsoft.AspNetCore.Mvc;
using _3dmarketplace.src.Models;
using _3dmarketplace.src.Services;

namespace _3dmarketplace.src.Controllers
{


    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {

        public required CategoryService _categoryService;
        CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        private static readonly List<Category> _category = [];

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_category);
        }


        [HttpGet("{id}")]
        public ActionResult<Category> GetProduct(int id)
        {
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Category product)
        {

            if (product == null)
            {
                return BadRequest();
            }

            var response = await _categoryService.Create(product);
            return Ok();
        }

    }

}
