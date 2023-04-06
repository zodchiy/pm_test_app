using AutoMapper;
using MinimalApi.Endpoint;
using TestApp.Core.Entities.UserAggregade;
using TestApp.Core.Interfaces;
using TestApp.WebApi.CountryEndpoint;

namespace TestApp.WebApi.ProvinceEndpoint
{
    public class ProvinceListEndpoint : IEndpoint<IResult, IRepository<Province>>
    {
        private readonly IMapper _mapper;

        public ProvinceListEndpoint(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapGet("api/provinces",
                async (IRepository<Province> provinceRepository) =>
                {
                    return await HandleAsync(provinceRepository);
                })
               .Produces<ProvinceListResponse>()
               .WithTags("ProvinceEndpoints");
        }
        public async Task<IResult> HandleAsync(IRepository<Province> provinceRepository)
        {
            var response = new ProvinceListResponse();
            var items = await provinceRepository.ListAsync();
            response.Provinces.AddRange(items.Select(_mapper.Map<ProvinceDTO>));
            return Results.Ok(response);
        }
    }
}
