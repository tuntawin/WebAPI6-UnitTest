using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI6.Models.Models;

namespace WebAPI6.Repository.Interfaces
{
    public interface ICategoriesRepository
    {
        Task<Category> GetById(int id);
        Task<IList<Category>> GetAll();
        Task<int> Add(Category session);
        int Update(Category session);
        Task<int> Delete(int id);
    }
}
