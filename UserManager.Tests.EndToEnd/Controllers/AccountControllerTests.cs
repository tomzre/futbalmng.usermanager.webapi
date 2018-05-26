using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using UserManager.Api;
using UserManager.Infrastructure.Commands.Users;

namespace UserManager.Tests.EndToEnd.Controllers
{
    public class AccountControllerTests : ControllerTestsBase
    { 
        [Test]
        public async Task given_valid_current_password_and_new_password_it_should_be_changed()
        {
            var command = new ChangeUserPassword
            { 
                CurrentPassword ="secret",
                NewPassword = "newpassword"  
            };

            var payload = GetPayload(command);
            var response = await Client.PutAsync("/password", payload);
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NoContent);
        }
    }
}