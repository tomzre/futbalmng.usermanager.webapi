using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace UserManager.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IUserService _userService;
        private readonly ILogger _logger;

        public DataInitializer(IUserService userService, ILogger<DataInitializer> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        public async Task SeedAsync()
        {
            _logger.LogTrace("Initialize data...");
            var tasks = new List<Task>();
            for (int i = 0; i <= 10; i++)
            {
                var userId = Guid.NewGuid();
                var userName = $"user{i}";
                tasks.Add(_userService.RegisterAsync(userId, $"{userName}@test.com", userName, "password", "user"));
            }


            for (int i = 0; i <= 3; i++)
            {
                var userId = Guid.NewGuid();
                var userName = $"admin{i}";
                tasks.Add(_userService.RegisterAsync(userId, $"{userName}@test.com", userName, "password", "admin"));
            }
            await Task.WhenAll(tasks);
            _logger.LogTrace("Data has been initiliazed.");
        }
    }
}