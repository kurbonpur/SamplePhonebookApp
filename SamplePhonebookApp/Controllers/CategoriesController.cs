using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamplePhonebookApp.Models.DTOs;
using SamplePhonebookApp.Services;
using System.Threading.Tasks;

namespace SamplePhonebookApp.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetListOfCategories());
        }

        [Authorize(Roles = "admin, superadmin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "admin, superadmin")]
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto category)
        {
           await _service.CreateCategory(category);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin, superadmin")]
        public async Task<IActionResult> Edit(int? id)
        {          
            if (id != null)
            {
                CategoryDto category = await _service.GetCategoryByID(id);
                if (category != null)
                    return View(category);
            }
            return NotFound();
        }

        [Authorize(Roles = "admin, superadmin")]
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDto category)
        {
            await _service.EditCategory(category);                      
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin, superadmin")]
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                CategoryDto category = await _service.GetCategoryByID(id);
                if (category != null)
                    return View(category);
            }
            return NotFound();
        }

        [Authorize(Roles = "admin, superadmin")]
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                CategoryDto category = await _service.GetCategoryByID(id);
                if (category != null)
                {
                    await _service.Delete(id);                    
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

    }
}