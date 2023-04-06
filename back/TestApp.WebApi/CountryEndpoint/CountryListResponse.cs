namespace TestApp.WebApi.CountryEndpoint
{
    public class CountryListResponse : BaseResponse
    {
        public CountryListResponse(Guid correlationToken) : base(correlationToken)
        {
        }

        public CountryListResponse()
        {
        }

        public List<CountryDTO> Countries { get; set; } = new List<CountryDTO>();
    }
}
