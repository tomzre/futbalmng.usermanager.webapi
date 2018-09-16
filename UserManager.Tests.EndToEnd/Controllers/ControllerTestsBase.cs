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
            return "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhYWFhMTcxMS1hZDQ0LTQ1ZjYtYjYxYy0wNTNhYTg2YTk0YWUiLCJ1bmlxdWVfbmFtZSI6ImFhYWExNzExLWFkNDQtNDVmNi1iNjFjLTA1M2FhODZhOTRhZSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluIiwianRpIjoiNDY2YmM3ZTgtN2QwYS00Mzg5LTk3MTktOTBjMGNhOGI2YjhiIiwiaWF0IjoxNTM3MDk5MzA4LCJuYmYiOjE1MzcwOTkzMDgsImV4cCI6MTU5NzA5OTI0OCwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MjI0OSJ9.F9ue06jq2Caa_2XZfTYzgSAirPMIoKbiKM7guUFlLUE";
        }
    }
}