using System;
using NUnit.Framework;
using UserManager.Core.Domain;
using FluentAssertions;
using NUnit.Framework.Constraints;

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
        public void setting_wrong_email_should_throw_exception(){
            // Act
            string wrongPassword = "dupadupa";

            // Arrange
            Action act = () => User.SetEmail(wrongPassword);

            // Assert
            act.Should().Throw<FormatException>()
                .WithMessage("Invalid email.");
        }

    }
}