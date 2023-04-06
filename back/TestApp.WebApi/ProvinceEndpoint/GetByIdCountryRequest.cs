namespace TestApp.WebApi.ProvinceEndpoint
{
    public class GetByIdCountryRequest : BaseRequest
    {
        public int CountryId { get; init; }

        public GetByIdCountryRequest(int countryId)
        {
            CountryId = countryId;
        }
    }
}
