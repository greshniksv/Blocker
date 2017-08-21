using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Blocker.Exceptions
{
    public class IncorrectKeyException : Exception
    {
        public IncorrectKeyException()
        {
        }

        public IncorrectKeyException(string message) : base(message)
        {
        }

        public IncorrectKeyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IncorrectKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
