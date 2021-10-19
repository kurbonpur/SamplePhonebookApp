using AutoMapper;
using SamplePhonebookApp.Models;
using SamplePhonebookApp.Models.DTOs;
using SamplePhonebookApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamplePhonebookApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task CreateCategory(CategoryDto categoryDto)
        {
            Category category = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.CreateCategory(category);
        }

        public async Task Delete(int? id)
        {
          await  _categoryRepository.Delete(id); 
        }

        public async Task EditCategory(CategoryDto categoryDto)
        {

            Category category = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.EditCategory(category);
        }

        public async Task<CategoryDto> GetCategoryByID(int? id)
        {
            Category category= await _categoryRepository.GetCategoryByID(id);
            var res = _mapper.Map<CategoryDto>(category);    
            return await Task.FromResult(res);
        }
        public async Task<IList<CategoryDto>> GetListOfCategories()
        {
            var categories = await _categoryRepository.GetListOfCategories();
            return categories.Select(x => _mapper.Map<CategoryDto>(x)).ToList();
        }
    }
}
