using Back_End.IService;
using Back_End.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Back_End.Service
{
    public class UserService : IUserService
    {
        ApplicationDbContext _dbContext;
        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public FeUser Login(InputLoginUser loginUser)
        {
            var user = _dbContext.Users.Where(user => user.Email == loginUser.Email).FirstOrDefault();
            if(user == null)
            {
                return null;
            }

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(loginUser.Password, user.PasswordHash);
            if(isValidPassword)
            {
                return new FeUser(user.Username, user.Email, "token");
            }

            return null;
        }

        public FeUser Register(User oUser)
        {
            oUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(oUser.PasswordHash);
            _dbContext.Users.Add(oUser);
            _dbContext.SaveChanges();
            return new FeUser(oUser.Username, oUser.Email, "token");
        }
    }
}
