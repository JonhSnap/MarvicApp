using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Utilities.Exceptions
{
    [Serializable]
    public class MarvicException : Exception
    {
        public MarvicException()
        {
        }

        public MarvicException(string message) : base(message)
        {
        }

        public MarvicException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MarvicException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
