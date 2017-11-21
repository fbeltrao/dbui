using System;
using System.Runtime.Serialization;

namespace dbui
{
    [Serializable]
    public class MissingParameterException : Exception
    {
        public MissingParameterException()
        {
        }

        public MissingParameterException(string message) : base(message)
        {
        }

        public MissingParameterException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MissingParameterException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}