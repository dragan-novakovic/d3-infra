using Microsoft.AspNetCore.Mvc;
using _3dmarketplace.src.Models;
using _3dmarketplace.src.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using _3dmarketplace.src.Models.Category;

namespace _3dmarketplace.src.Controllers
{


    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {

        public required CategoryService _categoryService;
        public CategoryController(CategoryService categoryService)
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
        public ActionResult<Category> GetCategory(int id)
        {
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Allow)] CategoryDto category_dto)
        {
            if (category_dto == null)
            {
                return BadRequest(error: "Category is null");
            }

            var category = new Category
            {
                Name = category_dto.Name,
                Products = []
            };

            await _categoryService.Create(category);
            return Ok();
        }

    }

}
