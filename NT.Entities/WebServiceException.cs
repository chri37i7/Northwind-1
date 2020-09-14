using System;
using System.Runtime.Serialization;

namespace NT.Entities
{
    [Serializable]
    public class WebServiceException : Exception
    {
        public WebServiceException()
        {
        }

        public WebServiceException(string message) : base(message)
        {
        }

        public WebServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WebServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}