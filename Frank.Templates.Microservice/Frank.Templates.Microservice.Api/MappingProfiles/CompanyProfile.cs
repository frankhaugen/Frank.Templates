using AutoMapper;

using Frank.Templates.Microservice.Client.Models.Responses;
using Frank.Templates.Microservice.Models.Companies;

namespace Frank.Templates.Microservice.Api.MappingProfiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyResponse>();
            CreateMap<Address, AddressResponse>();
            CreateMap<BusinessArea, BusinessAreaResponse>();
            CreateMap<Variant, VariantResponse>();
            CreateMap<CompaniesList, CompaniesResponse>()
                .ForMember(x => x.Companies, opt => opt.MapFrom(x => x.Data.Companies))
            ;
        }
    }
}
