﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Fribergs_Alpha.Models
{
    public class Booking
    {
        [DisplayName("Booking ID")]
        public int BookingId { get; set; }
        [Required]
        public Car? Car { get; set; }
        [DisplayName("Pick-up Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Required]
        // TODO: Changed to DateTime for better compatibility - unsure if it works
        public DateTime PickUpDate { get; set; }
        [DisplayName("Return Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Required]
        public DateTime ReturnDate { get; set; }
        [DisplayName("Total Sum")]
        public double? TotalSum { get; set; }
        [DisplayName("Customer"), Required]
        public User? User { get; set; }
        

        public Booking()
        {
            PickUpDate = DateTime.Now;
            ReturnDate = DateTime.Now;
            //PickUpDate = DateOnly.FromDateTime(DateTime.Now);
            //ReturnDate = DateOnly.FromDateTime(DateTime.Now);
        }
    }
}