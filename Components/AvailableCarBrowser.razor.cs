using Fribergs_Alpha.Models;
using Microsoft.AspNetCore.Components;

namespace Fribergs_Alpha.Components
{
    public partial class AvailableCarBrowser
    {
        [SupplyParameterFromForm]
        public DateCategoryFilter FilterData { get; set; } = new DateCategoryFilter();

        public List<CarCategory> AvailableCategories { get; set; } = new List<CarCategory>();

        public List<Booking> AllFutureBookings { get; set; } = default!;

        public List<Booking> ConflictingBookings { get; set; } = default!;

        public List<Car> FilteredCars { get; set; } = default!;

        public bool InputFault { get; set; } = false;

        public string? Message { get; set; }




        protected override void OnInitialized()
        {
            AllFutureBookings = BookingRepository.GetAllBookings().Where(x => x.PickUpDate >= DateTime.Now.Date).ToList();

            AvailableCategories = CategoryRepository.GetAllCarCategories().ToList();
        }

        public void ListAvailableCars()
        {
            // (Start A <= End B) && (End A >= Start B) = Overlap

            ConflictingBookings = AllFutureBookings
                .Where(x => (x.PickUpDate <= FilterData.FilterEndDate) &&
                      (x.ReturnDate >= FilterData.FilterStartDate))
                .ToList();

            


        }



    }
}
