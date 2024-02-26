﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Fribergs_Alpha.Models
{
    public class Admin
    {
        [DisplayName("Employee ID")]
        public int AdminId { get; set; }
        [DisplayName("First Name"), MaxLength(50)]
        public string FirstName { get; set; } = "";
        [DisplayName("Last Name"), MaxLength(50)]
        public string LastName { get; set; } = "";
        [DisplayName("Address")]
        public string Address { get; set; } = "";
        [DisplayName("E-mail"), EmailAddress, Required]
        public string Email { get; set; } = "";
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; } = "";
        [DisplayName("Password"), PasswordPropertyText, Required]
        public string Password { get; set; } = "";
        // If an admin makes a booking for a customer, this will be registered in the database
        [DisplayName("Booking")]
        public List<Booking>? Bookings { get; set; }
    }
}
