using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserManager.Infrastructure.Commands;
using UserManager.Infrastructure.Commands.Users;

namespace UserManager.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        public AccountController(ICommandDispatcher commandDispatcher) 
            : base(commandDispatcher)
        {
        }


        [HttpPut("{password}")]
        public async Task<IActionResult> Put([FromBody]ChangeUserPassword command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }
    }
}