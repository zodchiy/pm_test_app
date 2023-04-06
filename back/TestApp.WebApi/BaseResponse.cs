namespace TestApp.WebApi
{
    /// <summary>
    /// Base class used by API responses
    /// </summary>
    public abstract class BaseResponse : BaseMessage
    {
        public BaseResponse(Guid correlationToken) : base()
        {
            base._correlationToken = correlationToken;
        }

        public BaseResponse()
        {
        }
    }
}
