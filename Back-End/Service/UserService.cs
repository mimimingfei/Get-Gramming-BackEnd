using Back_End.IService;
using Back_End.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Back_End.Service
{
    public class UserService : IUserService
    {
        private ApplicationDbContext _dbContext;
        private IConfiguration _config;
        public UserService(ApplicationDbContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
        }

        public async Task<ActionResult<FeUser>> Login(InputLoginUser loginUser)
        {
            var user = _dbContext.Users.Where(user => user.Email == loginUser.Email).FirstOrDefault();
            if (user == null)
            {
                return new NotFoundObjectResult($"User with email {loginUser.Email} not found");
            }

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(loginUser.Password, user.PasswordHash);
            if (isValidPassword)
            {
                return new FeUser(user.Id, user.Username, user.Email, generateToken(user));
            }

            return new UnauthorizedObjectResult("Incorrect password");
        }

        public async Task<ActionResult<FeUser>> Register(User oUser)
        {
            var user = _dbContext.Users.Where(
                user => user.Email == oUser.Email || user.Username == oUser.Username)
                .FirstOrDefault();
            if (user != null)
            {
                return new ConflictObjectResult($"{oUser.Email} or {oUser.Username} already exists");
            }

            oUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(oUser.PasswordHash);
            _dbContext.Users.Add(oUser);
            _dbContext.SaveChanges();
            var registeredUser = _dbContext.Users
                .Where(user => user.Username == oUser.Username)
                .FirstOrDefault();

            return new FeUser(registeredUser.Id, oUser.Username, oUser.Email, generateToken(oUser));
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }
        public async Task<User> GetUserById(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        private string generateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                    new Claim(ClaimTypes.NameIdentifier, user.Username),
                    new Claim(ClaimTypes.Email, user.Email)
                };

            var token = new JwtSecurityToken( claims: claims, signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
