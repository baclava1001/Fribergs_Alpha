namespace Fribergs_Alpha.Models
{
    public class DateCategoryFilter
    {
        
        public DateTime FilterStartDate { get; set; } = DateTime.Now;
        public DateTime FilterEndDate { get; set; } = DateTime.Now.AddDays(30);

        public int CategoryId { get; set; }
    }
}
