using System;
using System.Collections.Generic;
using System.Linq;
using UserManager.Core.Domain;
using UserManager.Core.Repositories;

namespace UserManager.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>{
            new User("user1@internet.com", "username1", "pass", "sol", "Admin"),
            new User("user2@internet.com", "username2", "pass", "sol", "Admin"),
            new User("user3@internet.com", "username3", "pass", "sol", "Admin")
        };
        public void Add(User user)
        {
            _users.Add(user);
        }

        public User Get(Guid id)
            => _users.Single(x => x.Id == id);

        public User Get(string email)
            => _users.Single(x => x.Email == email.ToLowerInvariant());

        public IEnumerable<User> GetAll()
            => _users;

        public void Remove(Guid id)
        {
            var user = Get(id);
            _users.Remove(user);
        }

        public void Update(User user)
        {
        }
    }
}