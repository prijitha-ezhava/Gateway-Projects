using HMS.BAL.Interface;
using HMS.DAL.Repository;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BAL
{
    public class HotelDetails : IHotelDetails
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelDetails(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public string BookRoom(Booking model)
        {
            return _hotelRepository.BookRoom(model);
        }

        public bool CheckBooking(DateTime date)
        {
            return _hotelRepository.CheckBooking(date);
        }

        public string CreateHotel(Hotel model)
        {
            return _hotelRepository.CreateHotel(model);
        }

        public string CreateRoom(Room model)
        {
            return _hotelRepository.CreateRoom(model);
        }

        public string DeleteBooking(int Id)
        {
            return _hotelRepository.DeleteBooking(Id);
        }

        
        public List<Hotel> GetAllHotels()
        {
            return _hotelRepository.GetAllHotels();
        }


        public Hotel GetHotel(int Id)
        {
            return _hotelRepository.GetHotel(Id);
        }

        public List<Room> GetRoomsByParameter(string Category, string City, string Pincode, string Price)
        {
            return _hotelRepository.GetRoomsByParameter(Category, City, Pincode, Price);
        }

        /* public IQueryable GetRoomsByParameter(Hotel model)
         {
             return _hotelRepository.GetRoomsByParameter(model);
         }*/

        public string UpdateBookingDate(Booking model, int id)
        {
            return _hotelRepository.UpdateBookingDate(model,id);
        }

        public string UpdateBookingStatus(Booking model, int id)
        {
            return _hotelRepository.UpdateBookingStatus(model,id);
        }
    }
}
