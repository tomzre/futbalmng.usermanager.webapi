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
    [Route("[controller]")]
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
            Console.WriteLine("logger: " + _settings.Name);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
               var user = await _usersService.GetAsync(email);
               if(user != null)
               {
                    return Ok(user);
               }
               
                return NotFound($"User with {email} not exists.");
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            try{
                await CommandDispatcher.DispatchAsync(command);     
                
                return Created($"users/{command.Email}", new object());

            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
