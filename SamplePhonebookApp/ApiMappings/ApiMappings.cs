using AutoMapper;
using SamplePhonebookApp.Models;
using SamplePhonebookApp.Models.DTOs;

namespace SamplePhonebookApp.ApiMappings
{
    public class ApiMappings : Profile
    {
        public ApiMappings()
        {
            this.CreateMap<Phone, PhoneDto>();
            this.CreateMap<PhoneDto, Phone>();

            this.CreateMap<Category, CategoryDto>();
            this.CreateMap<CategoryDto, Category>();
        }
    }
}
