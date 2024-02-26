using Fribergs_Alpha.Models;

namespace Fribergs_Alpha.Data
{
    public interface IBooking
    {
        IEnumerable<Booking> GetAllBookings();
        Booking GetBookingById(int? id);
        void AddBooking(Booking booking);
        void UpdateBooking(Booking booking, int id);
        void DeleteBooking(int? id);
    }
}
