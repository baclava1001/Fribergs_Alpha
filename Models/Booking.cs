using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Fribergs_Alpha.Models
{
    public class Booking
    {
        [DisplayName("Booking ID")]
        public int BookingId { get; set; }
        [Required]
        public Car BookedCar { get; set; }
        [DisplayName("Pick-up Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Required]
        public DateOnly PickUpDate { get; set; }
        [DisplayName("Return Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Required]
        public DateOnly ReturnDate { get; set; }
        [DisplayName("Total Sum")]
        public double? TotalSum { get; set; }
        [DisplayName("Customer"), Required]
        public Customer Customer { get; set; }
        [DisplayName("Employee")]
        public string? AdministratorName { get; set; }

        public Booking()
        {
            PickUpDate = DateOnly.FromDateTime(DateTime.Now);
            ReturnDate = DateOnly.FromDateTime(DateTime.Now);
            AdministratorName = null;
        }
    }
}