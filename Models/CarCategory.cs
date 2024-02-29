using System.ComponentModel.DataAnnotations;

namespace Fribergs_Alpha.Models
{
    public class CarCategory
    {
        public int CarCategoryId { get; set; }
        [Required]
        public string Category { get; set; } = "";
    }
}