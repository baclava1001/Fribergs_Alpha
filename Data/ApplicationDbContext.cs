using Fribergs_Alpha.Models;
using Microsoft.EntityFrameworkCore;

namespace Fribergs_Alpha.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarCategory> CarCategories { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        //public DbSet<Admin> Admins { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
