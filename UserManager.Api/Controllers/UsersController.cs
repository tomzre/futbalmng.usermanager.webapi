using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserManager.Infrastructure.Commands;
using UserManager.Infrastructure.Commands.Users;
using UserManager.Infrastructure.DTO;
using UserManager.Infrastructure.Services;
using UserManager.Infrastructure.Settings;

namespace UserManager.Api.Controllers
{
    public class UsersController : ApiControllerBase
    {
        private readonly IUserService _usersService;
        private readonly GeneralSettings _settings;

        public UsersController(IUserService userService,
            ICommandDispatcher commandDispatcher,
            GeneralSettings settings): base(commandDispatcher)
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
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
               
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            try{
                await DispatchAsync(command);     
                
                return Created($"users/{command.Email}", null);

            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        // PUT api/values/5
        [HttpGet]
        public async Task<IActionResult> BrowseAsync()
        {
            var users = await _usersService.BrowseAsync();

            return Json(users);
        }
        
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
