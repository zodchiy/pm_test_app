using AutoMapper;
using MinimalApi.Endpoint;
using TestApp.Core.Entities.UserAggregade;
using TestApp.Core.Interfaces;
using TestApp.Core.Specifications;

namespace TestApp.WebApi.ProvinceEndpoint
{
    public class ProvinceGetByIdCountryEndpoint : IEndpoint<IResult, GetByIdCountryRequest, IRepository<Province>>
    {
        private readonly IMapper _mapper;

        public ProvinceGetByIdCountryEndpoint(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapGet("api/provinces/{countryid}",
                async (int countryid, IRepository<Province> provinceRepository) =>
                {
                    return await HandleAsync(new GetByIdCountryRequest(countryid), provinceRepository);
                })
               .Produces<ProvinceListResponse>()
               .WithTags("ProvinceEndpoints");
        }
        public async Task<IResult> HandleAsync(GetByIdCountryRequest request, IRepository<Province> provinceRepository)
        {
            var response = new ProvinceListResponse(request.CorrelationToken());
            var spec = new ProvinceFilterSpecification(request.CountryId);
            var items = await provinceRepository.ListAsync(spec);
            response.Provinces.AddRange(items.Select(_mapper.Map<ProvinceDTO>));
            return Results.Ok(response);
        }
    }
}
