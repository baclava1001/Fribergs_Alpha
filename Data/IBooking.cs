﻿using Fribergs_Alpha.Models;

namespace Fribergs_Alpha.Data
{
    public interface IBooking
    {
        IQueryable<Booking> GetAllBookings();
        IQueryable<Booking> GetAllBookingsByUser(int userId);
        Booking GetBookingById(int? id);
        void AddBooking(Booking booking);
        void UpdateBooking(Booking booking);
        void DeleteBooking(Booking booking);
    }
}
