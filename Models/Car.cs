using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fribergs_Alpha.Models
{
    public class Car
    {
        public int CarId { get; set; }
        [DisplayName("Maker")]
        public string Brand { get; set; } = "";
        [DisplayName("Model")]
        public string CarModel { get; set; } = "";
        public int Year { get; set; }
        public string Color { get; set; } = "";
        public string Description { get; set; } = "";
        [DisplayName("Price per day"), Required]
        public double PricePerDay { get; set; }
        [DisplayName("Category"), Required]
        //[ForeignKey("CarCategoryId")]
        public CarCategory? Category { get; set; } = new CarCategory();
        //public int CarCategoryId { get; set; }
        [DisplayName("Picture")]
        public string CarPicUrl { get; set; } = "";
    }
}
