using System;
using System.Runtime.Serialization;

namespace SpheroLib
{
    [Serializable]
    public class OutOfRingsRangeException : Exception
    {
        public OutOfRingsRangeException()
        {
        }

        public OutOfRingsRangeException(string message) : base(message)
        {
        }

        public OutOfRingsRangeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OutOfRingsRangeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}