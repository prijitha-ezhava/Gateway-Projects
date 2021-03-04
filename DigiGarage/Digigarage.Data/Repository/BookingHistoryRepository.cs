using Digigarage.BusinessEntities;
using Digigarage.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using Digigarage.Data.Models;
using AutoMapper;
using System.Data.Entity;
using System.Linq;

namespace Digigarage.Data.Repository
{
    public class BookingHistoryRepository : IBookingHistoryRepository
    {
        private readonly DigigarageEntities _dbContext;
        public BookingHistoryRepository()
        {
            _dbContext = new DigigarageEntities();
        }
        public BookingHistoryViewModel GetBookingHistory(int? Id)
        {
            int bookingId = (int)Id;
            IEnumerable<BookingHistory> bookingHistory = _dbContext.BookingHistories.Where(a => a.BookingId == bookingId);
            BookingHistoryViewModel bookingsEntities = Mapper.Map<BookingHistoryViewModel>(bookingHistory.LastOrDefault()) ;
            return bookingsEntities;
        }
        public string updateBookingHistory(BookingHistoryViewModel bookingHistory)
        {
            if (bookingHistory != null)
            {
                BookingHistory entity = _dbContext.BookingHistories.Find(bookingHistory.HistoryId);
                Mapper.Map(bookingHistory, entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
                _dbContext.SaveChanges();
                Booking booking = _dbContext.Bookings.Where(a => a.BookingId == bookingHistory.BookingId).First();
                if(booking.ServiceId == 4 && booking.DepartmentId == 2)
                {
                    booking.DepartmentId = 1;
                    _dbContext.Entry(booking).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                    BookingHistory addBookingHistory = new BookingHistory();
                    addBookingHistory.ServiceId = bookingHistory.ServiceId;
                    addBookingHistory.BookingId = bookingHistory.BookingId;
                    addBookingHistory.VehicleId = bookingHistory.VehicleId;
                    addBookingHistory.DepartmentId = 1;
                    _dbContext.BookingHistories.Add(addBookingHistory);
                    _dbContext.SaveChanges();
                }
                else if (booking.ServiceId == 5 && booking.DepartmentId == 3)
                {
                    booking.DepartmentId = 1;
                    _dbContext.Entry(booking).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                    BookingHistory addBookingHistory = new BookingHistory();
                    addBookingHistory.ServiceId = bookingHistory.ServiceId;
                    addBookingHistory.BookingId = bookingHistory.BookingId;
                    addBookingHistory.VehicleId = bookingHistory.VehicleId;
                    addBookingHistory.DepartmentId = 1;
                    _dbContext.BookingHistories.Add(addBookingHistory);
                    _dbContext.SaveChanges();
                }
                else
                {
                    booking.Status = 3;
                    _dbContext.Entry(booking).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                }
                return "Booking updated";
            }
            return "Model is null";
        }
    }
}
