using Fribergs_Alpha.Models;

namespace Fribergs_Alpha.Data
{
    public class CarCategoryRepository : ICarCategory
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CarCategoryRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        public CarCategory GetCarCategoryById(int? id)
        {
            return _applicationDbContext.CarCategories.FirstOrDefault(c => c.CarCategoryId == id);
        }

        public IEnumerable<CarCategory> GetAllCarCategories()
        {
            return _applicationDbContext.CarCategories;
        }

        public void AddCarCategory(CarCategory carCategory)
        {
            _applicationDbContext.Add(carCategory);
            _applicationDbContext.SaveChanges();
        }

        public void UpdateCarCategory(CarCategory carCategory)
        {
            _applicationDbContext.Update(carCategory);
            _applicationDbContext.SaveChanges();
        }

        public void DeleteCarCategory(CarCategory carCategory)
        {
            _applicationDbContext.Remove(carCategory);
            _applicationDbContext.SaveChanges();
        }
    }
}
