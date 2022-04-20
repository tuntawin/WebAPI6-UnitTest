using WebAPI6.Models.Models;
using WebAPI6.Repository.Interfaces;
using WebAPI6.Services.Interfaces;

namespace WebAPI6.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoriesRepository _categoryRepo;

        public CategoryServices(ICategoriesRepository categoriesRepository)
        {
            _categoryRepo = categoriesRepository;
        }

        public Task<IList<Category>> GetAllCategories()
        {
            try
            {
                return _categoryRepo.GetAll();
            }
            catch
            {
                //Log and throw
                throw;
            }
        }

        public Task<Category> GetCategory(int id)
        {
            try
            {
                return _categoryRepo.GetById(id);
            }
            catch
            {
                //Log and throw
                throw;
            }
        }

        public Task<int> DeleteCategory(int id)
        {
            try
            {
                return _categoryRepo.Delete(id);
            }
            catch
            {
                //Log and throw
                throw;
            }
        }
    }
}