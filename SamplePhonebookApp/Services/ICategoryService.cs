using SamplePhonebookApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamplePhonebookApp.Services
{
   public interface ICategoryService
    {
        Task CreateCategory(CategoryDto categoryDto);
        Task Delete(int? id);
        Task EditCategory(CategoryDto categoryDto);
        Task<CategoryDto> GetCategoryByID(int? id);
        Task<IList<CategoryDto>> GetListOfCategories();
    }
}
