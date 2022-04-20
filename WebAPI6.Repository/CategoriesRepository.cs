using Microsoft.EntityFrameworkCore;
using WebAPI6.Models.Models;
using WebAPI6.Repository.Interfaces;

namespace WebAPI6.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly NORTHWND_UTContext _context;

        public CategoriesRepository(NORTHWND_UTContext _NORTHWND_UTContext)
        {
            _context = _NORTHWND_UTContext;    
        }

        public async Task<Category> GetById(int id)
        {
            Category? category = await _context.Categories.FindAsync(id);
            return category;
        }

        public async Task<IList<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<int> Add(Category session)
        {
            _context.Categories.Add(session);
            return await _context.SaveChangesAsync();
        }
        public int Update(Category session)
        {
            _context.Entry(session).State = EntityState.Modified;
            return _context.SaveChanges();
        }

        public async Task<int> Delete(int id)
        {
            var category = _context.Categories.SingleOrDefault(m => m.CategoryId == id);
            if (category == null)
            {
                return 0;
            }

            _context.Categories.Remove(category);
            return await _context.SaveChangesAsync();
        }
    }
}