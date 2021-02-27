using Assignment1.Business.Interface;
using Assignment1.BusinessEntities;
using Assignment1.Data.Models;
using Assignment1.WebAPI.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Assignment1.UnitTest
{
    public class PassengersUnitTest
    {
        private readonly Mock<IPassengerManager> _mockPassengerManager = new Mock<IPassengerManager>();
        private readonly PassengerController _passengerController;

        public PassengersUnitTest()
        {
            _passengerController = new PassengerController(_mockPassengerManager.Object);
        }


        //Add New Passenger
        [Fact]
        public void AddPassengerTestPass()
        {
            //Arrange
            var passenger = new PassengerViewModel();
            passenger.ID = 8;
            passenger.FirstName = "Raghav";
            passenger.LastName = "Singh";
            passenger.Mobile = "8523690147";
            var res = _mockPassengerManager.Setup(x => x.AddPassengers(passenger)).Returns("Passenger Added Success1fully!");

            //Act
            var result = _passengerController.PostPassenger(passenger);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void AddPassengerTestFail()
        {
            //Arrange
            var passenger = new PassengerViewModel();
            var res = _mockPassengerManager.Setup(x => x.AddPassengers(passenger)).Returns("Model is found null");

            //Act
            var result = _passengerController.PostPassenger(passenger);

            //Assert
            Assert.NotNull(result);
        }


        //Get List of all Passengers
        [Fact]
        public void GetAllPPassengersTestPass()
        {
            //Arrange
            var result = _mockPassengerManager.Setup(x => x.GetPassengers()).Returns(GetPassenger());

            //Act
            var actualResult = _passengerController.GetPassengers();

            //Assert
            Assert.Equal(3, actualResult.Count);
        }

        [Fact]
        public void GetAllPPassengersTestFail()
        {
            //Arrange
            var result = _mockPassengerManager.Setup(x => x.GetPassengers()).Returns(GetPassenger());

            //Act
            var actualResult = _passengerController.GetPassengers();

            //Assert
            Assert.NotEqual(4, actualResult.Count);
        }

        //Get User By Id
        [Fact]
        public void GetPassengerByIdTestPass()
        {
            //Arrange
            var passenger = new PassengerViewModel();
            passenger.ID = 1;
            passenger.FirstName = "Prijitha";
            passenger.LastName = "Ezhava";
            passenger.Mobile = "7418529630";
            var res = _mockPassengerManager.Setup(x => x.GetPassenger(passenger.ID)).Returns(passenger);

            //Act
            var result = _passengerController.GetPassenger(passenger.ID);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetPassengerByIdTestFail()
        {
            //Arrange
            var passenger = new PassengerViewModel();
            var res = _mockPassengerManager.Setup(x => x.GetPassenger(3)).Returns(passenger);

            //Act
            var result = _passengerController.GetPassenger(passenger.ID);

            //Assert
            Assert.Null(result);
        }

        //Update any existing Passenger
        [Fact]
        public void UpdatePassengerTestPass()
        {
            //Arrange
            var passenger = new PassengerViewModel();
            passenger.ID = 5;
            passenger.FirstName = "Diljeet";
            passenger.LastName = "RJ";
            passenger.Mobile = "8521369740";
            var res = _mockPassengerManager.Setup(x => x.UpdatePassengers(4, passenger)).Returns("Passenger Updated Successfully!");

            //Act
            var result = _passengerController.UpdatePassenger(4, passenger);

            //Assert
            Assert.Equal("Passenger Updated Successfully!", result);
        }

        [Fact]
        public void UpdatePassengerTestFail()
        {
            //Arrange
            var passenger = new PassengerViewModel();
            var res = _mockPassengerManager.Setup(x => x.UpdatePassengers(4, passenger)).Returns("Model is Found Null!");

            //Act
            var result = _passengerController.UpdatePassenger(4, passenger);

            //Assert
            Assert.NotEqual("Passenger Updated Successfully!", result);
        }

        //Delete any particular existing Passenger.
        [Fact]
        public void DeletePassengerTestPass()
        {
            //Arrange
            var passenger = new PassengerViewModel();
            passenger.ID = 5;
            var res = _mockPassengerManager.Setup(x => x.DeletePassenger(passenger.ID)).Returns(true);

            //Act
            var result = _passengerController.DeletePassenger(passenger.ID);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void DeletePassengerTestFail()
        {
            //Arrange
            var passenger = new PassengerViewModel();
            passenger.ID = 5;
            var res = _mockPassengerManager.Setup(x => x.DeletePassenger(passenger.ID)).Returns(false);

            //Act
            var result = _passengerController.DeletePassenger(passenger.ID);

            //Assert
            Assert.False(result);
        }



        //Static List of Passengers
        private static List<PassengerViewModel> GetPassenger()
        {
            List<PassengerViewModel> users = new List<PassengerViewModel>()
            {
                new PassengerViewModel() {ID=1,FirstName="Prijitha",LastName="Ezhava",Mobile="7418529630"},
                new PassengerViewModel() {ID=2,FirstName="Prakash",LastName="Ezhava",Mobile="96385220147"},
                new PassengerViewModel() {ID=3,FirstName="Prijith",LastName="Ezhava",Mobile="96325801458"},

            };
            return users;
        }
    }
}
