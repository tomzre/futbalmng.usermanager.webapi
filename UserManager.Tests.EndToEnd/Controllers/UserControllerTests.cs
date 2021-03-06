using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using NUnit.Framework;
using UserManager.Api;
using UserManager.Infrastructure.DTO;
using FluentAssertions;
using System.Net;
using UserManager.Infrastructure.Commands.Users;
using System.Text;
using System;

namespace UserManager.Tests.EndToEnd.Controllers
{
    public class UserControllerTests : ControllerTestsBase
    {
        [Test]
        public async Task given_valid_email_user_should_exist()
        {
            var email = "user1@test.com";
            var response = await Client.GetAsync($"users/{email}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var user = JsonConvert.DeserializeObject<UserDto>(responseString);

            user.Email.Should().BeEquivalentTo(email);
        }
        
        [Test]
        public async Task given_invalid_email_user_should_throw_not_found_code()
        {
            
            var email = "user1000000@email.com";
            var response = await Client.GetAsync($"users/{email}");
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NotFound);
        }
         
        [Test]
        public async Task given_unique_email_user_should_be_created()
        {
            var command = new CreateUser
            {
                UserId = Guid.NewGuid(),
                Email = "test@email.com",
                Username = "testuser",
                Password = "secret",
                Role = "user"
            };

            var payload = GetPayload(command);
            var response = await Client.PostAsync("users", payload);
            response.Headers.Location.ToString().Should().BeEquivalentTo($"users/{command.Email}");

            var user = await GetUserAsync(command.Email);
            user.Email.Should().BeEquivalentTo(command.Email);
        }
        
        [Test]
        public async Task given_existing_email_user_should_not_be_created()
        {
            var command = new CreateUser
            {
                UserId = Guid.NewGuid(),
                Email = "user1@test.com",
                Username = "testuser",
                Password = "secret",
                Role = "user"
            };

            var payload = GetPayload(command);
            var response = await Client.PostAsync("users", payload);
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.BadRequest);
        }
        private async Task<UserDto> GetUserAsync(string email)
        {
            var response = await Client.GetAsync($"users/{email}");
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserDto>(responseString);
        }
    }
}