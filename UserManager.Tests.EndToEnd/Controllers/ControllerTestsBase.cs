using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using UserManager.Api;

namespace UserManager.Tests.EndToEnd.Controllers
{
    public abstract class ControllerTestsBase
    {
        protected readonly TestServer Server;
        protected readonly HttpClient Client;
        protected readonly string AuthToken;
        
        public ControllerTestsBase()
        {
             Server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            Client = Server.CreateClient();

            AuthToken = AuthorizationToken();
        }

        protected static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private static string AuthorizationToken(){
            return @"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ1c2VyMUBnbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsImp0aSI6IjhmYTE1MTI3LWRhYjEtNDc5MS1iODllLTAwMjU5ZmRkOTMwYiIsImlhdCI6MTUyOTEyNzQwNCwibmJmIjoxNTI5MTI3NDA0LCJleHAiOjIxMjkxMjczNDQsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTIyNDkifQ.X-z5ZKxyDNmNdghrJ7E0j1qKKRP-kOEKNzM0M5ev51A";
        }
    }
}