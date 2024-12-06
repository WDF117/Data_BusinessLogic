using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Data_BusinessLogic;
using Data_BusinessLogic.DB;

namespace UnitTestObject
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void ValidatePassword_CorrectPassword_ReturnsTrue()
        {
            var user = new User { Password = "1234" };
            Assert.IsTrue(user.ValidatePassword("1234"));
        }

        [TestMethod]
        public void ValidatePassword_IncorrectPassword_ReturnsFalse()
        {
            var user = new User { Password = "1234" };
            Assert.IsFalse(user.ValidatePassword("abcd"));
        }
    }
}
