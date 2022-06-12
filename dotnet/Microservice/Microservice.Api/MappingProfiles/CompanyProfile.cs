using AutoMapper;
using Microservice.Client.Models.Responses;
using Microservice.Models.Companies;

namespace Microservice.Api.MappingProfiles
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
