using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserManager.Infrastructure.Commands.Users;
using UserManager.Infrastructure.DTO;
using UserManager.Infrastructure.Services;

namespace UserManager.Api.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _usersService;
        public UsersController(IUserService userService)
        {
            _usersService = userService;
        }

        // GET api/values/5
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
        public async Task<IActionResult> Post([FromBody]CreateUser request)
        {
                var userFromDb = await _usersService.GetAsync(request.Email);
                if(userFromDb != null)
                {
                    return BadRequest($"user with {request.Email} already exists.");
                }
             
                await _usersService.RegisterAsync(request.Email, request.Username, request.Password);
                return Created($"users/{request.Email}", new object());
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
