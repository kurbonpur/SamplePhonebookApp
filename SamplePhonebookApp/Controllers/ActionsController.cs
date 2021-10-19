using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamplePhonebookApp.Models;
using SamplePhonebookApp.Services;
using System.Threading.Tasks;

namespace SamplePhonebookApp.Controllers
{
    public class ActionsController : Controller
    {
        private readonly IActionService _actionService;

        public ActionsController(IActionService actionService)
        {
            _actionService = actionService;
        }

        [Authorize]
        public async Task<IActionResult> Index(int category, string name, int page = 1,
             SortState sortOrder = SortState.NameAsc)
        {
            var res = await _actionService.Index(category, name, page, sortOrder);
            return  View(res);
        }
    }
}