using UserManager.Infrastructure.DTO;

namespace UserManager.Infrastructure.Services
{
    public interface IUserService
    {
        UserDto Get(string email);
         void Register(string email, string username, string password);
    }
}