using FluentAssertions;
using NUnit.Framework;
using System;
using UserManager.Core.Domain;
using UserManager.Core.Domain.Exceptions;

namespace UserManager.Tests.UserTests
{
    public class UserTest
    {
        public User User;
        [SetUp]
        public void Setup()
        {
            User = new User(Guid.NewGuid(), "palmask8@gmail.com", "username", "haslo", "sol", "Admin");
        }

        [Test]
        public void user_name_should_be_valid()
        {
            User.Username.Should().Be("username");
        }

        [Test]
        public void setting_wrong_username_should_throw_exception()
        {
            // Arrange 
            string wrongUserName = "#12";

            // Act
            Action act = () => User.SetUsername(wrongUserName);

            // Assert
            act.Should().Throw<Exception>()
                .WithMessage("Invalid username.");
        }
        [Test]
        public void setting_wrong_email_should_throw_exception()
        {
            // Arrange
            string wrongPassword = "dupadupa";

            // Act
            Action act = () => User.SetEmail(wrongPassword);

            // Assert
            act.Should().Throw<DomainException>()
                .WithMessage("Invalid email.");
        }

    }
}