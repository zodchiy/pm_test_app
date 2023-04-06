using AutoMapper;
using MinimalApi.Endpoint;
using TestApp.Core.Entities.UserAggregade;
using TestApp.Core.Interfaces;

namespace TestApp.WebApi.CountryEndpoint
{
    public class CountryListEndpoint : IEndpoint<IResult, IRepository<Country>>
    {

        private readonly IMapper _mapper;

        public CountryListEndpoint(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapGet("api/countries",
                async (IRepository<Country> countryRepository) =>
                {
                    return await HandleAsync(countryRepository);
                })
               .Produces<CountryListResponse>()
               .WithTags("CountryEndpoints");
        }
        public async Task<IResult> HandleAsync(IRepository<Country> countryRepository)
        {
            var response = new CountryListResponse();
            var items = await countryRepository.ListAsync();
            response.Countries.AddRange(items.Select(_mapper.Map<CountryDTO>));
            return Results.Ok(response);
        }
    }
}
