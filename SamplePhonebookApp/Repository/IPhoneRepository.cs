using SamplePhonebookApp.Models;
using SamplePhonebookApp.Models.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamplePhonebookApp.Repository
{
    public interface IPhoneRepository
    {
        public  Task CreatePhone(Phone phone);
        public  Task Delete(int? id);
        public  Task EditPhone(Phone phone);
        public  Task<IList<Phone>> GetListOfPhones();
        public  IQueryable<Phone> GetListOfPhonesWithCategory();
        public  Task<IList<PhoneAndCategoryDto>> GetListOfPhonesWithCategoryName();
        public  Task<Phone> GetPhoneByID(int? id);
    }
}