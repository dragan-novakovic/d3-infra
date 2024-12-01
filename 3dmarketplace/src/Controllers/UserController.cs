using Microsoft.AspNetCore.Mvc;

namespace _3dmarketplace.src.Controllers
{

    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [Route("roles")]
        [HttpGet]
        public IActionResult GetRoles()
        {
            return Ok("Roleeeers");
        }
    }
};