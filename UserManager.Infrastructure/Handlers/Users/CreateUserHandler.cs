using System;
using System.Threading.Tasks;
using UserManager.Infrastructure.Commands;
using UserManager.Infrastructure.Commands.Users;
using UserManager.Infrastructure.Services;

namespace UserManager.Infrastructure.Handlers.Users
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private IUserService _usersService;

        public CreateUserHandler(IUserService usersService)
        {
            _usersService = usersService;
        }
        public async Task HandleAsync(CreateUser command)
        {
                await _usersService.RegisterAsync(command.UserId, command.Email, command.Username, command.Password, command.Role);
        }
    }
}