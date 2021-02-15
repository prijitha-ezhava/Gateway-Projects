using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManagement.Controllers;

namespace PM.UnitTest
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void TestUsers()
        {
            //Arrange
            UserController uc = new UserController();

            //Act
            ViewResult result = uc.Users() as ViewResult;

            //Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void TestAddUserFail()
        {
            //Arrange
            UserController uc = new UserController();
            var user = "kirthy";
            //Act
            ViewResult result = uc.Users() as ViewResult;

            //Assert
            Assert.AreNotEqual(user, result);
        }
    }
}
