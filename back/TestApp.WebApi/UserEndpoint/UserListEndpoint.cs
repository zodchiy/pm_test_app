using AutoMapper;
using MinimalApi.Endpoint;
using TestApp.Core.Entities;
using TestApp.Core.Entities.UserAggregade;
using TestApp.Core.Interfaces;
using TestApp.WebApi.CountryEndpoint;

namespace TestApp.WebApi.UserEndpoint
{
    public class UserListEndpoint : IEndpoint<IResult, IRepository<User>>
    {

        private readonly IMapper _mapper;

        public UserListEndpoint(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapGet("api/users",
                async (IRepository<User> userRepository) =>
                {
                    return await HandleAsync(userRepository);
                })
               .Produces<UserListResponse>()
               .WithTags("UserEndpoints");
        }
        public async Task<IResult> HandleAsync(IRepository<User> userRepository)
        {
            var response = new UserListResponse();
            var items = await userRepository.ListAsync();
            response.Users.AddRange(items.Select(_mapper.Map<UserDTO>));
            return Results.Ok(response);
        }
    }
}
