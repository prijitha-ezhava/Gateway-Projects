using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiMVC.Controllers;
using WebApiMVC.Models;

namespace PM.UnitTest.ControllerTests
{
    [TestClass]
    public class ProductControllerTest
    {
    
        [TestMethod]
        public void GetProduct_ShouldReturnCorrectProduct()
        {
            //Arrange
            var testProducts = GetTestProducts();
            tbl_ProductsController controller = new tbl_ProductsController(testProducts);

            //Act
            var result = controller.Gettbl_Products(16) as OkNegotiatedContentResult<tbl_Products>;
            
            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetProduct_ShouldNotFindProduct()
        {
            //Arrange
            
            var controller = new tbl_ProductsController(GetTestProducts());
            //Act
            var result = controller.Gettbl_Products(80);

            //Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        private List<tbl_Products> GetTestProducts()
        {
            var testProducts = new List<tbl_Products>();
            testProducts.Add(new tbl_Products { 
                Prod_Name = "Balls",
                Prod_Category = "Sports", 
                Prod_Price = 100, 
                Prod_Quantity= 1, 
                Prod_Short_Des= "Cricket Ball Short Des1", 
                Prod_Long_Des = "Cricket Ball Long Des1", 
                });

            return testProducts;
        }
    }
}
