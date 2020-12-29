using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManagement.Context;
using ProductManagement.Controllers;

namespace ProductManagement.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            ProductController pc = new ProductController();

            //Act
            ViewResult result = pc.ProductList() as ViewResult;

            //Assert
            Assert.AreEqual("productList", result.ViewName);
        }
    }
}
