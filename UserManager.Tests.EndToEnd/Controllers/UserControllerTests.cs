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

namespace UserManager.Tests.EndToEnd.Controllers
{
    public class UserControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        
        public UserControllerTests()
        {
             _server = new TestServer(new WebHostBuilder()
            .UseStartup<Startup>());
            _client = _server.CreateClient();
        }
        
        [Test]
        public async Task given_valid_email_user_should_exist()
        {
            var email = "user1@email.com";
            var response = await _client.GetAsync($"users/{email}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var user = JsonConvert.DeserializeObject<UserDto>(responseString);

            user.Email.Should().BeEquivalentTo(email);
        }
        
        [Test]
        public async Task given_invalid_email_user_should_throw_not_found_code()
        {
            var email = "user1000000@email.com";
            var response = await _client.GetAsync($"users/{email}");
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NotFound);
        }
        
        [Test]
        public async Task given_unique_email_user_should_be_created()
        {
            var command = new CreateUser
            { 
                Email = "test@email.com",
                Username = "testuser",
                Password = "secret"    
            };

            var payload = GetPayload(command);
            var response = await _client.PostAsync("users", payload);
            response.Headers.Location.ToString().Should().BeEquivalentTo($"users/{command.Email}");

            var user = await GetUserAsync(command.Email);
            user.Email.Should().BeEquivalentTo(command.Email);
        }
        
        [Test]
        public async Task given_existing_email_user_should_not_be_created()
        {
            var command = new CreateUser
            { 
                Email = "user1@email.com",
                Username = "testuser",
                Password = "secret"    
            };

            var payload = GetPayload(command);
            var response = await _client.PostAsync("users", payload);
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.BadRequest);
        }

        protected static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private async Task<UserDto> GetUserAsync(string email)
        {
            var response = await _client.GetAsync($"users/{email}");
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserDto>(responseString);
        }

    }
}