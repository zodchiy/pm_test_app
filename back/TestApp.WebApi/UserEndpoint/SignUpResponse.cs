namespace TestApp.WebApi.UserEndpoint
{
    public class SignUpResponse : BaseResponse
    {
        public SignUpResponse(Guid correlationToken) : base(correlationToken)
        {
        }

        public SignUpResponse()
        {
        }
        public bool Result { get; set; } = false;
        public string Error { get; set; }
    }
}
