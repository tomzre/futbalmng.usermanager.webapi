using System;
using System.Threading.Tasks;
using UserManager.Infrastructure.DTO;

namespace UserManager.Infrastructure.Services
{
    public interface IUserService
    {
        Task<UserDto> GetAsync(string email);
         Task RegisterAsync(Guid userId, string email, string username, string password, string role);
         Task LoginAsync(string email, string password);
    }
}