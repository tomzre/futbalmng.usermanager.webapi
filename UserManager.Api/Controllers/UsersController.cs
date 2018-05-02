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
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            UserDto user = null;
            try{
                user = await _usersService.GetAsync(email);
                return Ok(user);
            }catch(Exception ex){
                return NotFound(ex.Message);
            }            
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]CreateUser request)
        {
            await _usersService.RegisterAsync(request.Email, request.Username, request.Password);
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
