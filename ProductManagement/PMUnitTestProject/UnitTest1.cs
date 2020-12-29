using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManagement.Context;
using ProductManagement.Controllers;

namespace PMUnitTestProject
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
            tbl_Products objProducts = new tbl_Products();
            //Assert
            Assert.AreEqual("Flower pot", objProducts.Prod_Name);
        }
    }
}
