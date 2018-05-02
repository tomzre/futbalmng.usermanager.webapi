using System;
using AutoMapper;
using UserManager.Core.Domain;
using UserManager.Core.Repositories;
using UserManager.Infrastructure.DTO;

namespace UserManager.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public UserDto Get(string email)
        {
            var user = _userRepository.Get(email);

                if(user == null)
                    throw new Exception("User not found.");

            return _mapper.Map<User, UserDto>(user);
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