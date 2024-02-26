using Fribergs_Alpha.Models;

namespace Fribergs_Alpha.Data
{
    public interface ICar
    {
        IEnumerable<Car> GetAllCars();
        Car GetCarById(int? id);
        void AddCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(Car car);
    }
}
