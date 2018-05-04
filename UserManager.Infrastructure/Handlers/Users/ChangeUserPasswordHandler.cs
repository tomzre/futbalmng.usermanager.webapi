using System.Threading.Tasks;
using UserManager.Infrastructure.Commands;
using UserManager.Infrastructure.Commands.Users;

namespace UserManager.Infrastructure.Handlers.Users
{
    public class ChangeUserPasswordHandler : ICommandHandler<ChangeUserPassword>
    {
        public async Task HandleAsync(ChangeUserPassword command)
        {
            await Task.CompletedTask;
        }
    }
}