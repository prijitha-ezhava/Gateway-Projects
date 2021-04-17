using Assignment7;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Tests
{
    public class Tests
    {
        //Create obj of class
        private Program prgObj;
        [SetUp]
        public void Setup()
        {
            //Arrange
            prgObj = new Program();
        }


        //--------------User Login Test---------------
        //--------------If Else-----------------------

        [TestCase("abc@gmail.com","12345", "Your credentials dont match our records!")]
        [TestCase("prijitha@gmail.com","Prijitha", "Welcome User")]
        public void UserShouldLogin(string email, string password, string message)
        {
            //Act
            string result = prgObj.UserLogin(email, password);
            //Assert
            Assert.AreEqual(message,result);
        }

        //---------------------Select Day Test---------------------
        //---------------------Switch case-------------------------
        [TestCase(1,"Sunday")]
        [TestCase(2, "Monday")]
        [TestCase(3, "Tuesday")]
        [TestCase(4, "Wednesday")]
        [TestCase(5, "Thursday")]
        [TestCase(6, "Friday")]
        [TestCase(7, "Saturday")]
        [TestCase(0, "You have selected an invalid day")]
        public void SwitchCaseTest(int choiceNumber, string day)
        {
            //Act
            string result = prgObj.SelectDay(choiceNumber);
            //Assert
            Assert.AreEqual(day, result);
        }


        //-------------------------Gender Count Test----------------------------
        //-------------------------For Each Loop [Positive]--------------------------------
        [Test]
        public void ForEachLoopTest_Positive()
        {
            //Act
            var result = prgObj.GenderCount();
            //Assert
            //For Male
            Assert.AreEqual(4, result[0]);
            //For Female
            Assert.AreEqual(6, result[1]);
        }

        //-------------------------Gender Count Test----------------------------
        //-------------------------For Each Loop [Negative]--------------------------------
        [Test]
        public void ForEachLoopTest_Negative()
        {
            //Act
            var result = prgObj.GenderCount();
            //Assert
            //For Male
            Assert.AreNotEqual(3, result[0]);
            //For Female
            Assert.AreNotEqual(4, result[1]);
        }

        //-------------------------Sum Of Numbers----------------------------
        //-------------------------While Loop [Positive]--------------------------------
        [Test]
        public void WhileLoopTest_Positive()
        {
            // Act
            int result = prgObj.SumOfNumbers(5);
            // Assert
            Assert.AreEqual(15, result);
        }

        //-------------------------Sum Of Numbers----------------------------
        //-------------------------While Loop [Negative]--------------------------------
        [Test]
        public void WhileLoopTest_Negative()
        {
            // Act
            int result = prgObj.SumOfNumbers(5);
            // Assert
            Assert.AreNotEqual(10, result);
        }

        //-------------------------Sum Of Numbers----------------------------
        //-------------------------While Loop [By Zero]--------------------------------
        [Test]
        public void WhileLoopTest_ByZero()
        {
            // Act
            int result = prgObj.SumOfNumbers(0);
            // Assert
            Assert.AreEqual(0, result);
        }

        //-------------------------Find Cube Test----------------------------
        //---------------------------For Loop [Positive]--------------------------------
        [Test]
        public void ForLoopTest_Positive()
        {
            //Act
            var result = prgObj.FindCube(5);
            //Assert
            Assert.AreEqual(125, result);
        }

        //-------------------------Find Cube Test----------------------------
        //---------------------------For Loop [Negative]--------------------------------
        [Test]
        public void ForLoopTest_Negative()
        {
            //Act
            var result = prgObj.FindCube(5);
            //Assert
            Assert.AreNotEqual(105, result);
        }

        //-------------------------Find Cube Test----------------------------
        //---------------------------For Loop [By Zero]--------------------------------
        [Test]
        public void ForLoopTest_ByZero()
        {
            //Act
            var result = prgObj.FindCube(0);
            //Assert
            Assert.AreEqual(0, result);
        }

        //----------------------------------------------------------------------------------------------------
        //-------------------------------------------Exception Testing----------------------------------------
        //----------------------------------------------------------------------------------------------------
        //-------------------------------Null Reference Exception-------------------
        [Test]
        public void SumOfNumbers_NegativeArgumentTest()
        {
            //Act
            var exceptionResult = Assert.Throws<NullReferenceException>(() => prgObj.SumOfNumbers(-2));

            //Assert
            Assert.AreEqual("Number is Negative", exceptionResult.Message);
        }

        //-------------------------------Divide By Zero Exception-----------------------------
        [Test]
        public void DivideByZeroExceptionTest()
        {
            //Act
            var exceptionResult = Assert.Throws<DivideByZeroException>(() => prgObj.DivisionOfNumbers(10,0));

            //Assert
            Assert.AreEqual("Divide By Zero Exception thrown", exceptionResult.Message);
        }

        //-------------------------------Index Out Of Bound Exception-----------------------------
        [Test]
        public void ArrayIndexOutOfBoundTest()
        {
            //Act
            var exceptionResult = Assert.Throws<IndexOutOfRangeException>(() => prgObj.ArrayIndexOutOfBound());

            //Assert
            Assert.AreEqual("Array Running Out of Index Bound", exceptionResult.Message);
        }


        //--------------------------------------------------------------------------------------------
        //-------------------------------------Async Method Testing ----------------------------------
        //--------------------------------------------------------------------------------------------
        [Test]
        public async Task AdditionAsyncMethodTest()
        {
            var result = await prgObj.Addition(10,20);
            Assert.AreEqual(30, result);
        }

        [Test(ExpectedResult = 30)]
        public async Task<int> AdditionAsyncMethodTest1()
        {
            return await prgObj.Addition(10, 20);
        }




    }
}