using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using UserManager.Core.Domain;
using UserManager.Core.Repositories;
using UserManager.Infrastructure.DTO;

namespace UserManager.Infrastructure.Services
{
    public class UserService : IUserService, IService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEncrypter _encrypter;

        public UserService(IUserRepository userRepository, IMapper mapper, IEncrypter encrypter)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _encrypter = encrypter;
        }

        public async Task<UserDto> GetAsync(string email)
        {
            var user = await _userRepository.GetAsync(email);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> BrowseAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            
            if(user == null)
            {
                throw new Exception($"User with email: '{email}' does not exists.");
            }

            var hash = _encrypter.GetHash(password, user.Salt);

            if(user.Password == hash){
                return;
            }
            throw new Exception("Invalid credentials.");
        }

        public async Task RegisterAsync(Guid userId, string email, string username, string password, string role)
        {
            var user = await _userRepository.GetAsync(email);
            
            if(user != null)
            {
                throw new Exception($"User with email: '{email}' already exists.");
            }

            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);

            user = new User(userId, email, username, hash, salt, role);

            await _userRepository.AddAsync(user);
        }
    }
}