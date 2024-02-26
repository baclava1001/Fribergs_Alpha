using Fribergs_Alpha.Models;
using Microsoft.EntityFrameworkCore;

namespace Fribergs_Alpha.Data
{
    public class BookingRepository : IBooking
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BookingRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            return _applicationDbContext.Bookings.Include(b => b.Car).Include(b => b.Customer).OrderBy(b => b.Customer.LastName).ThenBy(b => b.Customer.FirstName).ToList();
        }

        public Booking GetBookingById(int? bookingId)
        {
            return _applicationDbContext.Bookings.Include(b => b.Car).Include(b => b.Customer).FirstOrDefault(b => b.BookingId == bookingId);
        }

        public void AddBooking(Booking booking)
        {
            // Undanta BookedCar och Customer från EF Cores operationer
            _applicationDbContext.Entry(booking.Car!).State = EntityState.Unchanged;
            _applicationDbContext.Entry(booking.Customer!).State = EntityState.Unchanged;
            
            _applicationDbContext.Add(booking);
            _applicationDbContext.SaveChanges();
        }

        public void UpdateBooking(Booking booking)
        {
            _applicationDbContext.Update(booking);
            _applicationDbContext.SaveChanges();
        }

        public void DeleteBooking(Booking booking)
        {
            _applicationDbContext.Remove(booking);
            _applicationDbContext.SaveChanges();
        }
    }
}
