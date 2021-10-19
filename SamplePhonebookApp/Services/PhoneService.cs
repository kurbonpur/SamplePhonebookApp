using AutoMapper;
using SamplePhonebookApp.Models;
using SamplePhonebookApp.Models.DTOs;
using SamplePhonebookApp.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamplePhonebookApp.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly IPhoneRepository _phoneRepository;
        private readonly IMapper _mapper;

        public PhoneService(IPhoneRepository phoneRepository, IMapper mapper)
        {
            _phoneRepository = phoneRepository;
            _mapper = mapper;
        }

        public async Task CreatePhone(PhoneDto phoneDto)
        {
            Phone phone = _mapper.Map<Phone>(phoneDto);
            await _phoneRepository.CreatePhone(phone);
        }

        public async Task Delete(int? id)
        {
            await _phoneRepository.Delete(id);
        }

        public async Task EditPhone(PhoneDto phoneDto)
        {
            Phone phone = _mapper.Map<Phone>(phoneDto);
            await _phoneRepository.EditPhone(phone);
        }
        public async Task<IList<PhoneDto>> GetListOfPhones()
        {
            var phones = await _phoneRepository.GetListOfPhones();
            return phones.Select(x => _mapper.Map<PhoneDto>(x)).ToList();
        }
        public IQueryable<Phone> GetListOfPhonesWithCategory()
        {
            return _phoneRepository.GetListOfPhonesWithCategory();
        }
        public Task<IList<PhoneAndCategoryDto>> GetListOfPhonesWithCategoryName()
        {
            return _phoneRepository.GetListOfPhonesWithCategoryName();
        }
        public async Task<PhoneDto> GetPhoneByID(int? id)
        {
            Phone result = await _phoneRepository.GetPhoneByID(id);
            var res = _mapper.Map<PhoneDto>(result);
            return res;
        }
    }
}
