using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Threading.Tasks;
using UserManager.Infrastructure.Commands;
using UserManager.Infrastructure.Commands.Users;
using UserManager.Infrastructure.Services;
using UserManager.Infrastructure.Settings;

namespace UserManager.Api.Controllers
{
    public class UsersController : ApiControllerBase
    {
        private readonly IUserService _usersService;
        private readonly GeneralSettings _settings;
        private static Logger Logger = LogManager.GetCurrentClassLogger();

        public UsersController(IUserService userService,
            ICommandDispatcher commandDispatcher,
            GeneralSettings settings) : base(commandDispatcher)
        {
            _usersService = userService;
            _settings = settings;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            try
            {
                var user = await _usersService.GetAsync(email);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            await DispatchAsync(command);

            return Created($"users/{command.Email}", null);
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAsync()
        {
            Logger.Info("Fetching Drivers");
            var users = await _usersService.BrowseAsync();

            return Json(users);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
