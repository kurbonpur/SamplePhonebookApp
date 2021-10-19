using SamplePhonebookApp.Models;
using SamplePhonebookApp.Models.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamplePhonebookApp.Services
{
    public interface IPhoneService
    {
        public Task CreatePhone(PhoneDto phoneDto);
        public Task Delete(int? id);
        public Task EditPhone(PhoneDto phoneDto);
        public Task<IList<PhoneDto>> GetListOfPhones();
        public IQueryable<Phone> GetListOfPhonesWithCategory();
        public Task<IList<PhoneAndCategoryDto>> GetListOfPhonesWithCategoryName();
        public Task<PhoneDto> GetPhoneByID(int? id);
    }
}
