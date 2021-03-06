using AutoMapper;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using UserManager.Core.Domain;
using UserManager.Core.Repositories;
using UserManager.Infrastructure.Services;

namespace UserManager.Tests.Services
{
    public class UserServiceTest
    {
        [Test]
        public async Task register_async_should_invoke_add_async_on_repository()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var encrypterMock = new Mock<IEncrypter>();
            encrypterMock.Setup(x => x.GetSalt(It.IsAny<string>())).Returns("salt");
            encrypterMock.Setup(x => x.GetHash(It.IsAny<string>(), It.IsAny<string>())).Returns("hash");

            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object, encrypterMock.Object);

            await userService.RegisterAsync(Guid.NewGuid(), "user@email.com", "user", "password", "user");

            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }
    }
}