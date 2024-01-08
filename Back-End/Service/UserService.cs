using Back_End.IService;
using Back_End.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

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

        public FeUser Login(InputLoginUser loginUser)
        {
            var user = _dbContext.Users.Where(user => user.Email == loginUser.Email).FirstOrDefault();
            if (user == null)
            {
                return null;
            }

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(loginUser.Password, user.PasswordHash);
            if (isValidPassword)
            {
                return new FeUser(user.Username, user.Email, generateToken(user));
            }

            return null;
        }

        public FeUser Register(User oUser)
        {
            oUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(oUser.PasswordHash);
            _dbContext.Users.Add(oUser);
            _dbContext.SaveChanges();

            return new FeUser(oUser.Username, oUser.Email, generateToken(oUser));
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
