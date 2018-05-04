using UserManager.Infrastructure.Commands;

namespace UserManager.Api.Controllers
{
    public abstract class ApiControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public ApiControllerBase(ICommandDispatcher commandDispatcher)
        {
         _commandDispatcher = commandDispatcher;
        }
    }
}