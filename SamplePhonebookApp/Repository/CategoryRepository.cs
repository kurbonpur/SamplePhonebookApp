using Microsoft.EntityFrameworkCore;
using NLog;
using SamplePhonebookApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SamplePhonebookApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationContext _context;
        private readonly ILogger _logger;

        public CategoryRepository(ApplicationContext context)
        {
            _context = context;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public async Task<IList<Category>> GetListOfCategories()
        {
            try
            {
                _logger.Info("Get List Of Categories is Completed ");
                return await _context.Categories.ToListAsync();
            }
            catch (Exception exp)
            {
                _logger.Error("Get List Of Categories is Failed:" + exp.Message);
                return null;
            }
        }

        public async Task CreateCategory(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                _logger.Info("Create the new Category is Completed ");
            }
            catch (Exception exp)
            {
                _logger.Error("Create the new Category is Failed:" + exp.Message);
            }
        }

        public async Task EditCategory(Category category)
        {
            try
            {
                _context.Categories.Update(category);
                await _context.SaveChangesAsync();
                _logger.Info("Update the Category is Completed ");
            }
            catch (Exception exp)
            {
                _logger.Error("Update the Category is Failed:" + exp.Message);
            }
        }


        public async Task<Category> GetCategoryByID(int? id)
        {
            try
            {
                Category category = await _context.Categories.FirstOrDefaultAsync(p => p.Id == id);
                _logger.Info("Get Category By ID is Completed ");
                return category;
            }
            catch (Exception exp)
            {
                _logger.Error("Get Category By ID  is Failed:" + exp.Message);
                return null;
            }
        }

        public async Task Delete(int? id)
        {
            try
            {
                Category category = await _context.Categories.FirstOrDefaultAsync(p => p.Id == id);
                if (category != null)
                {
                    _context.Categories.Remove(category);
                    await _context.SaveChangesAsync();
                    _logger.Info("Delete Category is Completed ");
                }

            }
            catch (Exception exp)
            {
                _logger.Error("Delete Category  is Failed:" + exp.Message);
            }
        }

    }
}
