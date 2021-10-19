using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamplePhonebookApp.Models.DTOs;
using SamplePhonebookApp.Services;
using System.Threading.Tasks;

namespace SamplePhonebookApp.Controllers
{
    public class PhonesController : Controller
    {
        private readonly IPhoneService _service;

        public PhonesController(IPhoneService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetListOfPhones());
        }

        [Authorize(Roles = "admin, superadmin")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "admin, superadmin")]
        [HttpPost]
        public async Task<IActionResult> Create(PhoneDto phone)
        {
            await _service.CreatePhone(phone);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin, superadmin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                PhoneDto phone =await _service.GetPhoneByID(id);
                if (phone != null)
                    return View(phone);
            }
            return NotFound();
        }

        [Authorize(Roles = "admin, superadmin")]
        [HttpPost]
        public async Task<IActionResult> Edit(PhoneDto phone)
        {
            await _service.EditPhone(phone);           
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin, superadmin")]
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                PhoneDto phone = await _service.GetPhoneByID(id);
                if (phone != null)
                    return View(phone);
            }
            return NotFound();
        }

        [Authorize(Roles = "admin, superadmin")]
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                await _service.Delete(id);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}