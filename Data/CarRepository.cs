using Fribergs_Alpha.Models;
using Microsoft.EntityFrameworkCore;

namespace Fribergs_Alpha.Data
{
    public class CarRepository : ICar
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CarRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        public Car GetCarById(int? id)
        {
            return _applicationDbContext.Cars.FirstOrDefault(c => c.CarId == id);
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _applicationDbContext.Cars.OrderBy(c => c.Brand).ThenBy(c => c.CarModel).ThenBy(c => c.CarId).ToList();
        }

        public void AddCar(Car car)
        {
            _applicationDbContext.ChangeTracker.Clear();
            _applicationDbContext.Add(car);
            _applicationDbContext.Entry(car.Category!).State = EntityState.Unchanged;
            _applicationDbContext.SaveChanges();
        }

        public void UpdateCar(Car car)
        {
            _applicationDbContext.ChangeTracker.Clear();
            _applicationDbContext.Update(car);
            _applicationDbContext.Entry(car.Category!).State = EntityState.Unchanged;
            _applicationDbContext.SaveChanges();
        }

        public void DeleteCar(Car car)
        {
            _applicationDbContext.Remove(car);
            _applicationDbContext.SaveChanges();
        }
    }
}
