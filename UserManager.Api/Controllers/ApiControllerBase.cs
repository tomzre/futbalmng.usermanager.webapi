using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserManager.Infrastructure.Commands;

namespace UserManager.Api.Controllers
{
    [Route("[controller]")]
    public abstract class ApiControllerBase : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;

        protected Guid UserId => User?.Identity?.IsAuthenticated  == true ?
            Guid.Parse(User.Identity.Name) :
            Guid.Empty;
        protected ApiControllerBase(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        protected async Task DispatchAsync<T>(T command) where T: ICommand
        {
            if(command is IAuthenticatedCommand authenticatedCommand)
            {
                authenticatedCommand.UserId = UserId;
            }

            await _commandDispatcher.DispatchAsync(command);
        }
    }
}