namespace TestApp.WebApi.UserEndpoint
{
    public class UserDTO
    {
        public string Identity { get; set; }
        public int CountrydId { get; private set; }
        public int ProvinceId { get; private set; }
    }
}
