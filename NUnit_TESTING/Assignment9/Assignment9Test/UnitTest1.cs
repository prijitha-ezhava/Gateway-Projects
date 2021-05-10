using Assignment9;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Assignment9Test
{
    public class Tests
    {
        //Create object of Student Class
        private Student student;

        [SetUp]
        public void Setup()
        {
            //Arrange
            //1.Create moq object
            var studentMoq = new Mock<Student>();

            //2. Setup the returnables
            studentMoq.Setup(x => x.GetAllStudents()).Returns(new List<Student>()
            {
               new Student
                {
                   Id = 101,
                   FirstName = "Prijitha",
                   LastName = "Ezhava"
                },
               new Student
                {
                   Id = 102,
                   FirstName = "Raghav",
                   LastName = "Singh"
                },
                new Student
                {
                   Id = 103,
                   FirstName = "Nidhi",
                   LastName = "Fulpagar"
                }
            });

            //3. Assign to Object When needed
            student = studentMoq.Object;
        }

        //---------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------- Custom Constraint ------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------
        [Test]
        public void RemoveLastCharacterConstraint_PositiveTest()
        {
            //Act
            string str = "Prijitha";

            //Assert
            Assert.That("Prijith", Is.RemoveLastCharacter(str));
        }

        [Test]
        public void RemoveLastCharacterConstraint_NegativeTest()
        {
            //Act
            string str = "Prijitha";

            //Assert
            Assert.AreNotEqual("Prijit", Is.RemoveLastCharacter(str));
        }

        [Test]
        public void RemoveLastCharacterConstraint_WithMultipleWords_PositiveTest()
        {
            //Act
            string str = "Prijitha Ezhava";

            //Assert
            Assert.That("Prijitha Ezhav", Is.RemoveLastCharacter(str));
        }

        [Test]
        public void RemoveLastCharacterConstraint_WithMultipleWords_Negative()
        {
            //Act
            string str = "Prijitha Ezhava";

            //Assert
            Assert.AreNotEqual("Prijith Ezhav", Is.RemoveLastCharacter(str));
        }

        [Test]
        public void RemoveLastCharacterConstraint_WithNumbers()
        {
            //Act
            string str = "Prijitha123";

            //Assert
            Assert.That("Prijitha12", Is.RemoveLastCharacter(str));
        }


        //---------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------- Moq Testing -------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------

        //Get Count of Students [Positive Test]
        [Test]
        public void GetCountofStudent_PositiveTest()
        {
            //
            Assert.True(student.GetAllStudents().Count == 3);
        }

        //Get Count of students [Negative Test ]
        [Test]
        public void GetCountofStudent_NegativeTest()
        {
            //
            Assert.False(student.GetAllStudents().Count == 4);
        }

        //Get FirstName By Id [Positive Test]
        [Test]
        public void GetFirstNameById_PositiveTest()
        {
            //Act
            var result = student.GetAllStudents().Where(x => x.Id == 101).FirstOrDefault();

            //Assert
            Assert.AreEqual("Prijitha", result.FirstName);
        }

        //Get FirstName By Id [Negative Test]
        [Test]
        public void GetFirstNameById_NegativeTest()
        {
            //Act
            var result = student.GetAllStudents().Where(x => x.Id == 101).FirstOrDefault();

            //Assert
            Assert.AreNotEqual("Raghav", result.FirstName);
        }

        //Get LastName By FirstName [Positive Test]
        [Test]
        public void GetLastNameByFirstName_PositiveTest()
        {
            //Act
            var result = student.GetAllStudents().Where(x => x.FirstName == "Prijitha").FirstOrDefault();

            //Assert
            Assert.AreEqual("Ezhava", result.LastName);
        }

        //Get LastName By FirstName [Negative Test]
        [Test]
        public void GetLastNameByFirstName_NegativeTest()
        {
            //Act
            var result = student.GetAllStudents().Where(x => x.FirstName == "Prijitha").FirstOrDefault();

            //Assert
            Assert.AreNotEqual("Singh", result.LastName);
        }
    }
}