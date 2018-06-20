using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken);
            var payload = GetPayload(command);

            payload.Headers.TryAddWithoutValidation("Authorization", "Bearer " + AuthToken);
            
            var response = await Client.PutAsync("account/password", payload);

            response.Headers.Add("Authorization", "Bearer " + AuthToken);
            
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NoContent);
        }
    }
}