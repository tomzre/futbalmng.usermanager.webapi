using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using UserManager.Infrastructure.Commands;
using UserManager.Infrastructure.Commands.Users;
using UserManager.Infrastructure.Extensions;
using UserManager.Infrastructure.Services;

namespace UserManager.Infrastructure.Handlers.Users
{
    public class LoginHandler : ICommandHandler<Login>
    {
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMemoryCache _cache;

        public LoginHandler(IUserService userService, 
            IJwtHandler jwtHandler, 
            IMemoryCache cache)
        {
            _userService = userService;
            _jwtHandler = jwtHandler;
            _cache = cache;
        }
        public async Task HandleAsync(Login command)
        {
           await  _userService.LoginAsync(command.Email, command.Password);

           var user = await _userService.GetAsync(command.Email);

           var jwt = _jwtHandler.CreateToken(command.Email, user.Role);

           _cache.SetJwt(command.TokenId, jwt);

        }
    }
}