using System;
using UserManager.Core.Domain;
using UserManager.Core.Repositories;
using UserManager.Infrastructure.DTO;

namespace UserManager.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDto Get(string email)
        {
            var user = _userRepository.Get(email);

                if(user == null)
                    throw new Exception("User not found.");

            return new UserDto
            {
             Id = user.Id,
             Username = user.Username,
             Email = user.Email,
             FullName = user.FullName,
             Role = user.Role
            };
        }

        public void Register(string email, string username, string password)
        {
            var user = _userRepository.Get(email);
            if(user != null)
            {
                throw new Exception($"User with email: '{email}' already exists");
            }

            var salt = Guid.NewGuid().ToString("N");

            user = new User(email, username, password, salt, "User");

            _userRepository.Add(user);
        }
    }
}