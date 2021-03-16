using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repository
{
    public interface IHotelRepository
    {
        Hotel GetHotel(int Id);
        List<Hotel> GetAllHotels();
        string CreateHotel(Hotel model);
        string CreateRoom(Room model);
        string BookRoom(Booking model);
        bool CheckBooking(DateTime date);
       /* List<Room> GetRoomsByCity(string City);
        List<Room> GetRoomsByPincode(string Pincode);
        List<Room> GetRoomsByPrice(string price);*/
        List<Room> GetRoomsByParameter(string Category, string City, string Pincode, string Price);
        string DeleteBooking(int Id);
       string UpdateBookingDate(Booking model, int id);
        string UpdateBookingStatus(Booking model, int id);
    }
}
