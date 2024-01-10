using Back_End.Models;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.IService
{
    public interface IUserService
    {
        Task<ActionResult<FeUser>> Register(User oUser);
        Task<ActionResult<FeUser>> Login(InputLoginUser loginUser);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById (int id);
        Task<User> GetUserByUsername(string username);
        User GetCurrentUserFromAuthToken(HttpContext httpContext);
    }
}
