using HMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly Database.DB_HMSEntities _dbContext;

        public HotelRepository()
        {
            _dbContext = new Database.DB_HMSEntities();
        }

        // POST Booked the room of hotel for particular date with (optional status)
        public string BookRoom(Booking model)
        {
            try
            {
                if(model!=null)
                {
                    var entity = _dbContext.tbl_Rooms.Find(model.rID);
                    Database.tbl_Rooms room = new Database.tbl_Rooms();
                    Database.tbl_Bookings booking = new Database.tbl_Bookings();

                    booking.bDate = model.bDate;
                    booking.bStatus = model.bStatus;
                    booking.rID = (int)model.rID;

                    entity.rIsActive = true;

                    _dbContext.tbl_Bookings.Add(booking);
                    _dbContext.SaveChanges();
                    return "Room Booked Successfully!";
                }
                return "No Data Found!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // GET availability of room on some particular date
        public bool CheckBooking(DateTime date)
        {
            var a = _dbContext.tbl_Bookings.Where(h => h.bDate == date.Date && (h.bStatus.Equals("optional") || h.bStatus.Equals("Definitive")) ).ToList();

            if (a.Count() < 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //POST 5-10 hotels with details of hotel and 3-5 rooms in each hotel with different price and different category.
        public string CreateHotel(Hotel model)
        {
            try
            {
                if(model!=null)
                { 
                    Database.tbl_Hotels entity = new Database.tbl_Hotels();

                    entity.hName = model.hName;
                    entity.hAddress = model.hAddress;
                    entity.hCity = model.hCity;
                    entity.hPincode = model.hPincode;
                    entity.hContactNumber = model.hContactNumber;
                    entity.hContactPerson = model.hContactPerson;
                    entity.hWebsite = model.hWebsite;
                    entity.hFacebook = model.hFacebook;
                    entity.hTwitter = model.hTwitter;
                    entity.hIsActive = model.hIsActive;
                    entity.hCreatedDate = model.hCreatedDate;
                    entity.hCreatedBy = model.hCreatedBy;
                    entity.hUpdatedDate = model.hUpdatedDate;
                    entity.hUpdatedBy = model.hUpdatedBy;

                    _dbContext.tbl_Hotels.Add(entity);
                    _dbContext.SaveChanges();

                    return "Data Added Successfully!";
                }
                return "Model is Null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //Post 3-5 rooms in each hotel with different price and different category.
        public string CreateRoom(Room model)
        {
            try
            {
                if (model != null)
                {
                    Database.tbl_Rooms rooms = new Database.tbl_Rooms();
                    rooms.hID = (int)model.hID;
                    rooms.rName = model.rName;
                    rooms.rCategory = model.rCategory;
                    rooms.rPrice = model.rPrice;
                    rooms.rIsActive = model.rIsActive;
                    rooms.rCreatedDate = model.rCreatedDate;
                    rooms.rCreatedBy = model.rCreatedBy;
                    rooms.rUpdatedDate = model.rUpdatedDate;
                    rooms.rUpdatedBy = model.rUpdatedBy;

                    _dbContext.tbl_Rooms.Add(rooms);
                    _dbContext.SaveChanges();
                    return "Rooms Added Successfully!";
                }
                return "Model is Null!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //DELETE delete booking by booking Id (change status Deleted – soft delete)
        public string DeleteBooking(int Id)
        {
            try
            {
                var booking = _dbContext.tbl_Bookings.Find(Id);
                var rooms = _dbContext.tbl_Rooms.Find(booking.rID);

                if (booking != null)
                {
                    booking.bStatus = "Deleted";
                    rooms.rIsActive = false;
                    _dbContext.SaveChanges();

                    return "Booking Deleted Successfully!";
                }
                return "No Data Found!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

  
        //GET all hotels sort by alphabetic order. Response: List of hotels 
        public List<Hotel> GetAllHotels()
        {
            List<Hotel> list = new List<Hotel>();

            var entities = _dbContext.tbl_Hotels.OrderBy(x=>x.hName).ToList();

            if (entities!=null)
            {
                foreach (var item in entities)
                {
                    Hotel hotel = new Hotel();

                    hotel.hID = item.hID;
                    hotel.hName = item.hName;
                    hotel.hAddress = item.hAddress;
                    hotel.hCity = item.hCity;
                    hotel.hPincode = item.hPincode;
                    hotel.hContactNumber = item.hContactNumber;
                    hotel.hContactPerson = item.hContactPerson;
                    hotel.hWebsite = item.hWebsite;
                    hotel.hFacebook = item.hFacebook;
                    hotel.hTwitter = item.hTwitter;
                    hotel.hIsActive = item.hIsActive;
                    hotel.hCreatedDate = item.hCreatedDate;
                    hotel.hCreatedBy = item.hCreatedBy;
                    hotel.hUpdatedDate = item.hUpdatedDate;
                    hotel.hUpdatedBy = item.hUpdatedBy;

                    list.Add(hotel);
                }
            }
            return list;
        }

        //Get Hotel by ID
        public Hotel GetHotel(int Id)
        {
            var entity = _dbContext.tbl_Hotels.Find(Id);

            Hotel hotel = new Hotel();
            if(entity!=null)
            { 
                hotel.hID = entity.hID;
                hotel.hName = entity.hName;
                hotel.hAddress = entity.hAddress;
                hotel.hCity = entity.hCity;
                hotel.hPincode = entity.hPincode;
                hotel.hContactNumber = entity.hContactNumber;
                hotel.hContactPerson = entity.hContactPerson;
                hotel.hWebsite = entity.hWebsite;
                hotel.hFacebook = entity.hFacebook;
                hotel.hTwitter = entity.hTwitter;
                hotel.hIsActive = entity.hIsActive;
                hotel.hCreatedDate = entity.hCreatedDate;
                hotel.hCreatedBy = entity.hCreatedBy;
                hotel.hUpdatedDate = entity.hUpdatedDate;
                hotel.hUpdatedBy = entity.hUpdatedBy;
            }

            return hotel;
        }

        public List<Room> GetRoomsByParameter(string Category, string City, string Pincode, string Price)
        {
            var entity = _dbContext.tbl_Rooms.Where(h => h.rCategory ==(Category) || h.tbl_Hotels.hCity==(City) || h.tbl_Hotels.hPincode.ToString()==(Pincode) || h.tbl_Hotels.hPincode.ToString()==(Price)).ToList();
            List<Room> list = new List<Room>();
            if (_dbContext != null)
            {
                foreach (var item in entity)
                {
                    Room room = new Room();
                    room.rID = item.rID;
                    room.hID = item.hID;
                    room.rName = item.rName;
                    room.rCategory = item.rCategory;
                    room.rPrice = item.rPrice;
                    room.rIsActive = item.rIsActive;
                    room.rCreatedDate = item.rCreatedDate;
                    room.rCreatedBy = item.rCreatedBy;
                    room.rUpdatedDate = item.rUpdatedDate;
                    room.rUpdatedBy = item.rUpdatedBy;
                    list.Add(room);
                }
            }
            return list;
        }

        //public List<Room> GetRoomsByCity(string City)
        //{
        //    var entity = _dbContext.tbl_Rooms.Where(h => h.tbl_Hotels.hCity.Equals(City)).ToList();
        //    List<Room> list = new List<Room>();
        //    if (_dbContext != null)
        //    {
        //        foreach (var item in entity)
        //        {
        //            Room room = new Room();
        //            room.rID = item.rID;
        //            room.hID = item.hID;
        //            room.rName = item.rName;
        //            room.rCategory = item.rCategory;
        //            room.rPrice = item.rPrice;
        //            room.rIsActive = item.rIsActive;
        //            room.rCreatedDate = item.rCreatedDate;
        //            room.rCreatedBy = item.rCreatedBy;
        //            list.Add(room);
        //        }
        //    }
        //    return list;
        //}

        //public List<Room> GetRoomsByPincode(string Pincode)
        //{
        //    var entity = _dbContext.tbl_Rooms.Where(h => h.tbl_Hotels.hPincode.ToString().Equals(Pincode)).ToList();
        //    List<Room> list = new List<Room>();
        //    if (_dbContext != null)
        //    {
        //        foreach (var item in entity)
        //        {
        //            Room room = new Room();
        //            room.rID = item.rID;
        //            room.hID = item.hID;
        //            room.rName = item.rName;
        //            room.rCategory = item.rCategory;
        //            room.rPrice = item.rPrice;
        //            room.rIsActive = item.rIsActive;
        //            room.rCreatedDate = item.rCreatedDate;
        //            room.rCreatedBy = item.rCreatedBy;
        //            list.Add(room);
        //        }
        //    }
        //    return list;
        //}

        //public List<Room> GetRoomsByPrice(string price)
        //{
        //    var entity = _dbContext.tbl_Rooms.Where(h => h.tbl_Hotels.hPincode.ToString().Equals(price)).ToList();
        //    List<Room> list = new List<Room>();
        //    if (_dbContext != null)
        //    {
        //        foreach (var item in entity)
        //        {
        //            Room room = new Room();
        //            room.rID = item.rID;
        //            room.hID = item.hID;
        //            room.rName = item.rName;
        //            room.rCategory = item.rCategory;
        //            room.rPrice = item.rPrice;
        //            room.rIsActive = item.rIsActive;
        //            room.rCreatedDate = item.rCreatedDate;
        //            room.rCreatedBy = item.rCreatedBy;
        //            list.Add(room);
        //        }
        //    }
        //    return list;
        //}

        //GET all rooms of hotels with optional parameter by hotel city, pin code, Price, Category.
        /*public IQueryable GetRoomsByParameter(Hotel model)
        {
          
            var roomInfo = from hotels in _dbContext.tbl_Hotels
                           join rooms in _dbContext.tbl_Rooms on hotels.hID equals rooms.hID
                           where hotels.hCity == model.hCity || hotels.hPincode == model.hPincode ||
                           orderby rooms.rPrice
                           select new
                           {
                               hotels.hID,
                               rooms.rID,
                               rooms.rName,
                               hotels.hName,
                               rooms.rCategory,
                               rooms.rPrice,
                               hotels.hPincode,
                               hotels.hCity,
                           };
            return roomInfo;
        }*/

        // PUT update booking date for any room by Id
        public string UpdateBookingDate(Booking model, int id)
        {
            try
            {
                var entity = _dbContext.tbl_Bookings.Find(id);
                if (entity != null)
                {
                    entity.bDate = model.bDate;
                    _dbContext.SaveChanges();
                    return "Data Updated Successfully!";
                }
                return "No Data Found!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        //PUT update booking status by booking Id(optional status to Definitive or Cancelled)
        public string UpdateBookingStatus(Booking model, int id)
        {
            try
            {
                var entity = _dbContext.tbl_Bookings.Find(id);
                if(entity!=null)
                {
                    entity.bStatus = model.bStatus;
                    _dbContext.SaveChanges();
                    return "Record Updated Successfully!";
                }
                return "No Data Found!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

