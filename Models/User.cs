using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Fribergs_Alpha.Models
{
    public class User
    {
        [DisplayName("User ID")]
        public int UserId { get; set; }

        [Required]
        [DisplayName("First name")]
        [MinLength(3, ErrorMessage = "First name must be at least 3 letters long")]
        [MaxLength(30, ErrorMessage = "First name cannot be longer than 30 letters")]
        [RegularExpression(@"^[a-zA-Z0-9._-]+$", ErrorMessage = "Special character are not allowed")]
        public string FirstName { get; set; } = "";

        [Required]
        [DisplayName("Last name")]
        [MinLength(3, ErrorMessage = "First name must be at least 3 letters long")]
        [MaxLength(30, ErrorMessage = "First name cannot be longer than 30 letters")]
        [RegularExpression(@"^[a-zA-Z0-9._-]+$", ErrorMessage = "Special character are not allowed")]
        public string LastName { get; set; } = "";

        [DisplayName("Address")]
        public string Address { get; set; } = "";

        [Required]
        [DisplayName("E-mail")]
        [RegularExpression(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = "";

        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; } = "";

        [Required]
        [PasswordPropertyText]
        [DisplayName("Password")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; } = "";

        [Required]
        public bool AdminRole { get; set; }

        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
