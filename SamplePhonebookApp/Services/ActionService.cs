using SamplePhonebookApp.Models;
using SamplePhonebookApp.Models.Actions;
using SamplePhonebookApp.Repository;
using System.Threading.Tasks;

namespace SamplePhonebookApp.Services
{
    public class ActionService : IActionService
    {
        private readonly IActionRepository _actionRepository;

        public ActionService(IActionRepository actionRepository)
        {
            _actionRepository = actionRepository;
        }

        public async Task<IndexViewModel> Index(int category, string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            return await _actionRepository.Index(category, name, page, sortOrder);
        }
    }
}
