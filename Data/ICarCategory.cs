using Fribergs_Alpha.Models;

namespace Fribergs_Alpha.Data
{
    public interface ICarCategory
    {
        IEnumerable<CarCategory> GetAllCarCategories();
        CarCategory GetCarCategoryById(int? id);
        void AddCarCategory(CarCategory carCategory);
        void UpdateCarCategory(CarCategory carCategory, int id);
        void DeleteCarCategory(int? id);
    }
}
