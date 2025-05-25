using AutoMapper;
using InsuranceApp.Application.DTOs;
using InsuranceApp.Domain.Entities;
using InsuranceApp.Domain.Entities.Enums;
using InsuranceApp.Presentation.ViewModels;

namespace InsuranceApp.Presentation
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // InsuredPerson
            CreateMap<InsuredPerson, InsuredPersonDto>().ReverseMap();
            CreateMap<InsuredPersonDto, InsuredPersonFormViewModel>().ReverseMap();

            // Insurance
            CreateMap<Insurance, InsuranceDto>()
                .ForMember(dest => dest.InsuranceType, opt => opt.MapFrom(src => src.InsuranceType.ToString()))
                .ForMember(dest => dest.InsuredPersonFullName, opt => opt.MapFrom(src => src.InsuredPerson.FirstName + " " + src.InsuredPerson.LastName));

            CreateMap<InsuranceDto, Insurance>()
                .ForMember(dest => dest.InsuranceType, opt => opt.MapFrom(src => Enum.Parse<InsuranceType>(src.InsuranceType)));

            CreateMap<InsuranceDto, InsuranceFormViewModel>().ReverseMap();
        }
    }
}
