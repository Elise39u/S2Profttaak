using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;
using DalLayer;

namespace UserTest
{
    [TestClass]
    public class UserTests
    {
        public UserLogic UserLogic = new UserLogic();

        [TestMethod]
        public void DoLogin()
        {
            string result = UserLogic.DoLogin("juju124", "123456");
            Assert.AreEqual("User found in database", result, "404 User not found, Monkeys are still searching");
        }

        [TestMethod]
        public void DoWrongLogin()
        {
            string result = UserLogic.DoLogin("juju125", "12345");
            Assert.AreEqual("User not found in database", result, "500 Monkeys are confused good job");
        }
    }
}
