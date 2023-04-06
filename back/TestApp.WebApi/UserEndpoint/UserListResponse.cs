using TestApp.WebApi.CountryEndpoint;

namespace TestApp.WebApi.UserEndpoint
{
    public class UserListResponse : BaseResponse
    {
        public UserListResponse(Guid correlationToken) : base(correlationToken)
        {
        }

        public UserListResponse()
        {
        }

        public List<UserDTO> Users { get; set; } = new List<UserDTO>();
    }
}
