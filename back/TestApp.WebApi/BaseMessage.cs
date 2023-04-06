namespace TestApp.WebApi
{
    /// <summary>
    /// Base class used by API requests
    /// </summary>
    public abstract class BaseMessage
    {
        /// <summary>
        /// Unique Identifier used by logging
        /// </summary>
        protected Guid _correlationToken = Guid.NewGuid();
        public Guid CorrelationToken() => _correlationToken;
    }
}
