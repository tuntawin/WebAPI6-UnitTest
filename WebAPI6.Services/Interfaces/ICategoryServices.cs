using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI6.Models.Models;

namespace WebAPI6.Services.Interfaces
{
    public interface ICategoryServices
    {
        Task<IList<Category>> GetAllCategories();
        Task<Category> GetCategory(int id);
        Task<int> DeleteCategory(int id);
    }
}
