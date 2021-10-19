using SamplePhonebookApp.Models;
using SamplePhonebookApp.Models.Actions;
using System.Threading.Tasks;

namespace SamplePhonebookApp.Services
{
    public interface IActionService
    {
        Task<IndexViewModel> Index(int category, string name, int page = 1, SortState sortOrder = SortState.NameAsc);
    }
}
