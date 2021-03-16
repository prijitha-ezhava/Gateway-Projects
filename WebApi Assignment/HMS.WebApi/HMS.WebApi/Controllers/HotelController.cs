using HMS.BAL.Interface;
using HMS.Models;
using System.Web.Http.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HMS.WebApi.Controllers
{
    [EnableCors(origins: "https://localhost:44392/", headers:"*",methods:"*")]
    public class HotelController : ApiController
    {
        private readonly IHotelDetails _hotelDetails;

        public HotelController(IHotelDetails hotelDetails)
        {
            _hotelDetails = hotelDetails;
        }

        [Route("api/Hotel/GetAllHotels")]
        // GET: api/Hotel
        public List<Hotel> GetAllHotels()
        {
            //TODO : Call Hotel

            var hotel = _hotelDetails.GetAllHotels();
            return hotel;
        }

        [Route("api/Hotel/GetRoomsByParameter/{category}/{city}/{pincode}/{price}")]
        public List<Room> GetRoomsByParameter(string Category, string City, string Pincode, string Price)
        {
            return _hotelDetails.GetRoomsByParameter(Category, City, Pincode, Price);
        }

        [Route("api/Hotel/Get/{id}")]
        // GET: api/Hotel/5
        public Hotel Get(int id)
        {
            return _hotelDetails.GetHotel(id);
        }

        [Route("api/Hotel/CreateHotel")]
        // POST: api/Hotel
        //Create Hotel
        public string CreateHotel([FromBody]Hotel model)
        {
            return _hotelDetails.CreateHotel(model);
        }

        [Route("api/Hotel/CreateRoom")]
        // POST: api/Hotel
        //Create Room
        public string CreateRoom([FromBody]Room model)
        {
            return _hotelDetails.CreateRoom(model);
        }


        [Route("api/Hotel/BookRoom")]
        // POST: api/Hotel
        //Book Room

        public string BookRoom([FromBody] Booking model)
        {
            return _hotelDetails.BookRoom(model);
        }


        [Route("api/Hotel/UpdateBookingDate/{id}")]
        // PUT: api/Hotel/5
        //Update Booking Date
        [HttpPut]
        public string UpdateBookingDate(int id, [FromBody] Booking model)
        {
            return _hotelDetails.UpdateBookingDate(model,id);
        }

        [Route("api/Hotel/UpdateBookingStatus/{id}")]
        //Update Booking Status
        [HttpPut]
        public string UpdateBookingStatus(int id, [FromBody] Booking model)
        {
            return _hotelDetails.UpdateBookingStatus(model,id);
        }

        [Route("api/Hotel/CheckBooking/{date}")]
        //Check Room Availability
        [HttpGet]
        public bool CheckBooking(DateTime date)
        {
            return _hotelDetails.CheckBooking(date);
        }

        [Route("api/Hotel/DeleteBooking/{id}")]
        // DELETE: api/Hotel/5
        public string DeleteBooking(int id)
        {
            return _hotelDetails.DeleteBooking(id);
        }
    }
}
