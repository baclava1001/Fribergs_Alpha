﻿namespace Fribergs_Alpha.Models
{
    public class DateFilter
    {
        
        public DateTime FilterStartDate { get; set; } = DateTime.Now;
        public DateTime FilterEndDate { get; set; } = DateTime.Now.AddDays(30);
    }
}
