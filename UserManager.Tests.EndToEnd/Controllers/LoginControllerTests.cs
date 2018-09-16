using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using UserManager.Infrastructure.Commands.Users;

namespace UserManager.Tests.EndToEnd.Controllers
{
    public class LoginControllerTests : ControllerTestsBase
    {
        [Test]
        public async Task given_valid_credentials_should_return_ok_status()
        {
            var command = new Login{
                Email = "user1@test.com",
                Password = "password"
            };

            var payload = GetPayload(command);

            var response = await Client.PostAsync("login", payload);
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.OK);
        }
    }
}