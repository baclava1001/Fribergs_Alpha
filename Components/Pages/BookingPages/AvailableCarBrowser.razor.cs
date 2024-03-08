using Fribergs_Alpha.Models;
using Microsoft.AspNetCore.Components;

namespace Fribergs_Alpha.Components.Pages.BookingPages
{
    public partial class AvailableCarBrowser
    {
        [SupplyParameterFromForm(FormName = "FilterData")]
        public DateCategoryFilter FilterData { get; set; } = new();

        public List<CarCategory> AvailableCategories { get; set; } = [];

        public List<Booking> AllFutureBookings { get; set; } = [];

        public List<Booking> ConflictingBookings { get; set; } = [];

        public List<Car> OccupiedCars { get; set; } = [];

        public List<Car> AvailableCars { get; set; } = [];

        public List<Car> FilteredCars { get; set; } = [];

        public bool InputFault { get; set; } = false;

        public string? Message { get; set; }




        protected override void OnInitialized()
        {
            AllFutureBookings = BookingRepository.GetAllBookings().Where(x => x.PickUpDate >= DateTime.Now.Date).ToList();

            AvailableCategories = CategoryRepository.GetAllCarCategories().ToList();
        }

        public void ListAvailableCars()
        {
            if (FilterData.FilterStartDate < FilterData.FilterEndDate && FilterData.FilterStartDate >= DateTime.Now.Date)
            {
                InputFault = false;
                var allCars = CarRepository.GetAllCars().ToList();

                // (Start A <= End B) && (End A >= Start B) = Overlap
                ConflictingBookings = AllFutureBookings
                    .Where(x => x.PickUpDate <= FilterData.FilterEndDate &&
                          x.ReturnDate >= FilterData.FilterStartDate)
                    .ToList();

                foreach (var booking in ConflictingBookings)
                {
                    OccupiedCars.Add(booking.Car!);
                }

                AvailableCars = allCars.Except(OccupiedCars).ToList();

                if (FilterData.CategoryId == 0)
                {
                    FilteredCars = AvailableCars;
                }
                else
                {
                    foreach (var car in AvailableCars)
                    {
                        if (car.Category!.CarCategoryId == FilterData.CategoryId)
                        {
                            FilteredCars.Add(car);
                        }
                    }
                }
            }
            else if (FilterData.FilterStartDate >= FilterData.FilterEndDate)
            {
                InputFault = true;
                Message = "Return date must be greater than Pickup date";
            }
            else if (FilterData.FilterStartDate < DateTime.Now.Date)
            {
                InputFault = true;
                Message = "Pickup date cannot be a historical date";
            }
        }

        public double TotalCost(double dailyPrice)
        {
            var days = (FilterData.FilterEndDate - FilterData.FilterStartDate).TotalDays;
            var totalCost = dailyPrice * days;

            return totalCost;
        }
    }
}
