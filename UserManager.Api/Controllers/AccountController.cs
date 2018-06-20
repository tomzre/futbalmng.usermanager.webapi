using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManager.Infrastructure.Commands;
using UserManager.Infrastructure.Commands.Users;
using UserManager.Infrastructure.Services;

namespace UserManager.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private readonly IJwtHandler _jwtHandler;

        public AccountController(ICommandDispatcher commandDispatcher,
            IJwtHandler jwtHandler) 
            : base(commandDispatcher)
        {
            _jwtHandler = jwtHandler;
        }

        [HttpGet("token")]
        public IActionResult Get()
        {
            var token = _jwtHandler.CreateToken("user1@gmail.com", "Admin");

            return Json(token);
        }

        [Authorize(Policy = "Admin")]
        [HttpGet("auth")]
        public IActionResult GetAuth()
        {
            return Ok();
        }

        [Authorize]
        [HttpPut("password")]
        public async Task<IActionResult> Put([FromBody]ChangeUserPassword command)
        {   
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }
    }
}