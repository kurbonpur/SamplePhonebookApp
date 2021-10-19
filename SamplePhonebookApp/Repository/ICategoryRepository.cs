using SamplePhonebookApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SamplePhonebookApp.Repository
{
    public interface ICategoryRepository
    {
        Task CreateCategory(Category category);
        Task Delete(int? id);
        Task EditCategory(Category category);
        Task<Category> GetCategoryByID(int? id);
        Task<IList<Category>> GetListOfCategories();
    }
}