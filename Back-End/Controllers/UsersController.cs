using Back_End.IService;
using Back_End.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Back_End.Controllers
{
    [Route("users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // POST users/register
        [HttpPost("register")]
        public FeUser Register([FromBody] User oUser)
        {
            return _userService.Register(oUser);
        }

        // POST users/login
        [HttpPost("login")]
        public FeUser Login([FromBody] InputLoginUser loginUser)
        {
            return _userService.Login(loginUser);
        }
    }
}
