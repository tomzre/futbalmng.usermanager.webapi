using UserManager.Infrastructure.DTO;

namespace UserManager.Infrastructure.Services
{
    public interface IUserService
    {
        UserDto GetDto(string email);
         void Register(string email, string username, string password);
    }
}