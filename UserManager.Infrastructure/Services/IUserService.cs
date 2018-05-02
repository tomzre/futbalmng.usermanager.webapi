using System.Threading.Tasks;
using UserManager.Infrastructure.DTO;

namespace UserManager.Infrastructure.Services
{
    public interface IUserService
    {
        Task<UserDto> GetAsync(string email);
         Task RegisterAsync(string email, string username, string password);
    }
}