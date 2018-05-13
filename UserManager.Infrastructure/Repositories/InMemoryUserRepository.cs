using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManager.Core.Domain;
using UserManager.Core.Repositories;

namespace UserManager.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository, IRepository
    {
        private static ISet<User> _users = new HashSet<User>{
            new User("user1@internet.com", "username1", "pass", "sol", "Admin"),
            new User("user2@internet.com", "username2", "pass", "sol", "Admin"),
            new User("user3@internet.com", "username3", "pass", "sol", "Admin"),
            new User("user1@email.com", "username", "pass", "sol", "Admin")
        };
        public async Task AddAsync(User user)
        {
            await Task.FromResult(_users.Add(user));
        }

        public async Task<User> GetAsync(Guid id)
            => await Task.FromResult(_users.SingleOrDefault(x => x.Id == id));

        public async Task<User> GetAsync(string email)
            => await Task.FromResult(_users.SingleOrDefault(x => x.Email == email.ToLowerInvariant()));

        public async Task<IEnumerable<User>> GetAllAsync()
            => await Task.FromResult(_users);

        public async Task RemoveAsync(Guid id)
        {
            var user = await GetAsync(id);
            await Task.FromResult(_users.Remove(user));
        }

        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }
    }
}