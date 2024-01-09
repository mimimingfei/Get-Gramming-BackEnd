using Back_End.IService;
using Back_End.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Back_End.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
      
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        // GET users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpGet("username/{username}")]
        public async Task<ActionResult<User>> GetUserByUsername(string username)
        {
            var user = await _userService.GetUserByUsername(username);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }



        // POST users/register
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<FeUser>> Register([FromBody] User oUser)
        {
            return await _userService.Register(oUser);
        }

        // POST users/login
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<FeUser>> Login([FromBody] InputLoginUser loginUser)
        {
            return await _userService.Login(loginUser);
        }
    
    }
}
