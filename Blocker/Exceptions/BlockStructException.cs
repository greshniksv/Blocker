using System;
using System.Runtime.Serialization;

namespace Blocker.Exceptions
{
    public class BlockStructException : Exception
    {
        public BlockStructException()
        {
        }

        public BlockStructException(string message) : base(message)
        {
        }

        public BlockStructException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BlockStructException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
