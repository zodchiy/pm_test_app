using AutoMapper;
using TestApp.Core.Entities.UserAggregade;
using TestApp.WebApi.CountryEndpoint;
using TestApp.WebApi.ProvinceEndpoint;

namespace TestApp.WebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Province, ProvinceDTO>();
            CreateMap<Country, CountryDTO>();
        }
    }
}
