using AutoMapper;
using TestApp.Core.Entities;
using TestApp.Core.Entities.UserAggregade;
using TestApp.WebApi.CountryEndpoint;
using TestApp.WebApi.ProvinceEndpoint;
using TestApp.WebApi.UserEndpoint;

namespace TestApp.WebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Province, ProvinceDTO>();
            CreateMap<Country, CountryDTO>();
            CreateMap<User, UserDTO>();
        }
    }
}
