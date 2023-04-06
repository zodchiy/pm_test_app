using TestApp.WebApi.ProvinceEndpoint;

namespace TestApp.WebApi.ProvinceEndpoint
{
    public class ProvinceListResponse : BaseResponse
    {
        public ProvinceListResponse(Guid correlationToken) : base(correlationToken)
        {
        }

        public ProvinceListResponse()
        {
        }

        public List<ProvinceDTO> Provinces { get; set; } = new List<ProvinceDTO>();
    }
}
