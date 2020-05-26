using LogicLayer;
using NUnit.Framework;

namespace Tests
{
    public class UserTest
    {
        public UserLogic userLogic;

        [SetUp]
        public void Setup()
        {
            userLogic = new UserLogic();
        }

        [Test]
        public void DoLogin()
        {
            string result = userLogic.DoLogin("juju124", "123456");
            Assert.AreEqual("User found in database", result, "User doesn`t exsits in the database");
        }

        [Test]
        public void DoWrongLogin()
        {
            string result = userLogic.DoLogin("juju125", "12345");
            Assert.AreEqual("User not found in database", result, "Something Wrong happend??");
        }
    }
}