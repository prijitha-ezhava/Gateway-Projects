using System;
using Xunit;
using Assignment2;
namespace Assignment2.Tests
{
    public class UnitTest1
    {
      
        //Return a string of lowercase to uppercase TEST PASS.
        [Fact]
        public void ConvertToUpperCaseTestPass()
        {
            //Arrange
            string inputString = "tEstPasS";
            //Act
            string result = inputString.ConvertToUpperCase();
            //Assert
            Assert.Equal("TESTPASS", result);
        }

        //Return a string of lowercase to uppercase TEST FAIL.
        [Fact]
        public void ConvertToUpperCaseTestFail()
        {
            //Arrange
            string inputString = "teStfAil";
            //Act
            string result = inputString.ConvertToUpperCase();
            //Assert
            Assert.NotEqual("Testfail", result);
        }

        //Return a string of Uppercase to Lowercase TEST PASS.
        [Fact]
        public void ConvertToLowerCaseTestPass()
        {
            //Arrange
            string inputString = "TeStpaSS";
            //Act
            string result = inputString.ConvertToLowerCase();
            //Assert
            Assert.Equal("testpass", result);
        }

        //Return a string of Uppercase to Lowercase TEST FAIL.
        [Fact]
        public void ConvertToLowerCaseTestFail()
        {
            //Arrange
            string inputString = "testFAIL";
            //Act
            string result = inputString.ConvertToLowerCase();
            //Assert
            Assert.NotEqual("TestFail", result);    
        }

        //Return a string to titlecase TeST PASS.
        [Fact]
        public void ConvertToTitleCaseTestPass()
        {
            //Arrange
            string inputString = "tESt pAss";
            //Act
            string result = inputString.ConvertToTitleCase();
            //Assert
            Assert.Equal("Test Pass", result);                                 //UPDATED.............
        }

        //Return a string to titlecase TEST FAIL.
        [Fact]
        public void ConvertToTitleCaseTestFail()
        {
            //Arrange
            string inputString = "tEST fAIL";
            //Act
            string result = inputString.ConvertToTitleCase();
            //Assert
            Assert.NotEqual("testfaiL", result);                                 //UPDATED.............
        }

        //Find if all the characters of a string is in Lower case TEST PASS.
        [Fact]
        public void HasAllLowerCaseTestPass()
        {
            //Arrange
            string inputString = "testpass";
            //Act
            bool result = inputString.HasAllLowerCase();
            //Assert
            Assert.True(result);
        }
        //Find if all the characters of a string is in Lower case TEST FAIL.
        [Fact]
        public void HasAllLowerCaseTestFail()
        {
            //Arrange
            string inputString = "TestFail";
            //Act
            bool result = inputString.HasAllLowerCase();
            //Assert
            Assert.False(result);
        }

        //Return a capitalized version of given input string TEST PASS.
        [Fact]
        public void CapitalizeStringTestPass()
        {
            //Arrange
            string inputString = "test pASS";
            //Act
            string result = inputString.CapitalizeString();
            //Assert
            Assert.Equal("Test pass",result);                               //UPDATED.............
        }

        //Return a capitalized version of given input string TEST FAIL.
        [Fact]
        public void CapitalizeStringTestFail()
        {
            //Arrange
            string inputString = "TEST FAIL";
            //Act
            string result = inputString.CapitalizeString();
            //Assert
            Assert.NotEqual("test fail",result);                              //UPDATED.............      
        }

        //Find if all the characters of a string is in upper case TEST PASS.
        [Fact]
        public void HasAllUpperCaseTestPass()
        {
            //Arrange
            string inputString = "TESTPASS";
            //Act
            bool result = inputString.HasAllUpperCase();
            //Assert
            Assert.True(result);
        }

        //Find if all the characters of a string is in upper case TEST FAIL.
        [Fact]
        public void HasAllUpperCaseTestFail()
        {
            //Arrange
            string inputString = "test Fail";
            //Act
            bool result = inputString.HasAllUpperCase();
            //Assert
            Assert.False(result);
        }

        //Function to identify whether given input string can be converted to a valid numeric value or not TEST PASS.
        [Fact]
        public void IsValidNumericTestPass()
        {
            //Arrange
            string inputString = "268";
            //Act
            bool result = inputString.IsValidNumeric();
            //Assert
            Assert.True(result);
        }

        //Function to identify whether given input string can be converted to a valid numeric value or not TEST FAIL.
        [Fact]
        public void IsValidNumericTestFail()
        {
            //Arrange
            string inputString = "R268";
            //Act
            bool result = inputString.IsValidNumeric();
            //Assert
            Assert.False(result);
        }

        //Function to remove the last character from given the string TEST PASS.
        [Fact]
        public void RemoveLastCharacterTestPass()
        {
            //Arrange
            string inputString = "TESTPASS";
            //Act
            string result = inputString.RemoveLastCharacter();
            //Assert
            Assert.Equal("TESTPAS", result);
        }

        //Function to remove the last character from given the string TEST PASS.
        [Fact]
        public void RemoveLastCharacterTestFail()
        {
            //Arrange
            string inputString = "testfail";
            //Act
            string result = inputString.RemoveLastCharacter();
            //Assert
            Assert.NotEqual("testfail", result);
        }

        //Get the word count from an input string TEST PASS
        [Fact]
        public void WordCountTestPass()
        {
            //Arrange
            string inputString = "Test Pass";
            //Act
            int result = inputString.WordCount();
            //Assert
            Assert.Equal(2, result);
        }

        //Get the word count from an input string TEST FAIL
        [Fact]
        public void WordCountTestFail()
        {
            //Arrange
            string inputString = "Test Fail";
            //Act
            int result = inputString.WordCount();
            //Assert
            Assert.NotEqual(3, result);
        }

        //Convert an input string to integer TEST PASS.
        [Fact]
        public void ConvertStringToIntegerTestPass()
        {
            //Arrange
            string inputString = "0897";
            //Act
            int? result = inputString.ConvertStringToInteger();
            //Assert
            Assert.Equal(0897, result);
        }

        //Convert an input string to integer TEST FAIL.
        [Fact]
        public void ConvertStringToIntegerTestFail()
        {
            //Arrange
            var inputString = "R1234";
            var expectedResult = 1234;
            //Act
            int result = inputString.ConvertStringToInteger();
            Console.WriteLine(result);
            
            //Assert
            Assert.NotEqual(expectedResult, result);                      //UPDATED.............
        }
    }
}
