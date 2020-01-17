using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManager.Core.Domain;
using UserManager.Core.Repositories;
using UserManager.Infrastructure.DTO;
using UserManager.Infrastructure.Exceptions;
using UserManager.Infrastructure.Extensions;

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
            var user = await _userRepository.GetOrFailAsync(email);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> BrowseAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetOrFailAsync(email);

            if (user == null)
            {
                throw new ServiceException(ErrorCodes.InvalidCredentials, "Invalid credentials.");
            }

            var hash = _encrypter.GetHash(password, user.Salt);

            if (user.Password == hash)
            {
                return;
            }
            throw new ServiceException(ErrorCodes.InvalidCredentials, "Invalid credentials.");
        }

        public async Task RegisterAsync(Guid userId, string email, string username, string password, string role)
        {
            var user = await _userRepository.GetAsync(email);

            if (user != null)
            {
                throw new ServiceException(ErrorCodes.EmailInUse, $"User with email: '{email}' already exists.");
            }

            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);

            user = new User(userId, email, username, hash, salt, role);

            await _userRepository.AddAsync(user);
        }
    }
}