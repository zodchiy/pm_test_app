using TestApp.Core.Entities.UserAggregade;

namespace TestApp.WebApi.UserEndpoint
{
    public class SignUpRequest : BaseRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int CountryId { get; set; }
        public int ProvinceId { get; set; }
    }
}
