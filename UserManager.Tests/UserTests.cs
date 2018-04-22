using NUnit.Framework;
using UserManager.Core.Domain;

namespace UserManager.Tests
{
    [TestFixture]
    public class UserTests
    {
        public User User;
        [SetUp]
        public void Setup(){
            User = new User("email@email.com", "dummy", "haslo", "sol");
        }

        [Test]
        public void user_email_should_have_valid_value(){
            Assert.AreEqual(User.Password, "haslo");
        }
    }
}