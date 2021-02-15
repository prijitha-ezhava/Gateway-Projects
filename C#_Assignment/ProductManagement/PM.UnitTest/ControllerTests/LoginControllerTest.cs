using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManagement.Controllers;

namespace PM.UnitTest
{
    [TestClass]
    public class LoginControllerTest
    {
        [TestMethod]
        public void TestLogin()
        {
            //Arrange
            LoginController lc = new LoginController();

            //Act
            ViewResult result = lc.Login() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestLoginFail()
        {
            //Arrange
            LoginController lc = new LoginController();
            var user = "";

            //Act
            ViewResult result = lc.Login() as ViewResult;

            //Assert
            Assert.AreNotEqual(user,result);
        }

    }
}
