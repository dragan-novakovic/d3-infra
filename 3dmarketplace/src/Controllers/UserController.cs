using _3dmarketplace.src.Services;
using Microsoft.AspNetCore.Mvc;

namespace _3dmarketplace.src.Controllers
{

    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [Route("roles")]
        [HttpGet]
        public IActionResult GetRoles()
        {
            return Ok("Roleeeers");
        }

        [Route("users")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetById(id);
            return Ok(user);
        }
    }
};