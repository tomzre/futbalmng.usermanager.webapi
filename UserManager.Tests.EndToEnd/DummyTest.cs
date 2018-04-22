using NUnit.Framework;

namespace UserManager.Tests.EndToEnd
{
    [TestFixture]
    public class DummyTest
    {
        [SetUp]
        public void Setup(){

        }
        [Test]
        public void dummy_test(){
            Assert.AreEqual("expect", "expect");
        }
    }
}