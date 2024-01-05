using Back_End.Models;

namespace Back_End.IService
{
    public interface IUserService
    {
        FeUser Register(User oUser);
        FeUser Login(InputLoginUser loginUser);
    }
}
