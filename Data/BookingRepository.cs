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

        public IQueryable<Booking> GetAllBookings()
        {
            return _applicationDbContext.Bookings.Include(b => b.Car).Include(b => b.User).OrderBy(b => b.BookingId).AsQueryable();
        }

        public IQueryable<Booking> GetAllBookingsByUser(int userId)
        {
            return _applicationDbContext.Bookings.Where(x => x.User!.UserId == userId).Include(b => b.Car).Include(b => b.User).OrderBy(b => b.BookingId).AsQueryable();
        }

        public Booking GetBookingById(int? bookingId)
        {
            return _applicationDbContext.Bookings.Include(b => b.Car).Include(b => b.User).FirstOrDefault(b => b.BookingId == bookingId);
        }

        public void AddBooking(Booking booking)
        {
            // Undanta BookedCar och Customer från EF Cores operationer
            _applicationDbContext.Entry(booking.Car!).State = EntityState.Unchanged;
            _applicationDbContext.Entry(booking.User!).State = EntityState.Unchanged;
            
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
