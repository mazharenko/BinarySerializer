using System;
using System.Runtime.Serialization;

namespace BinarySerializer.Exceptions
{
    [Serializable]
    public class UnexpectedStreamEndException : StreamReaderException
    {
        public UnexpectedStreamEndException() : this("Unexpected end of stream has been detected")
        {
        }

        public UnexpectedStreamEndException(string message) : base(message)
        {
        }

        public UnexpectedStreamEndException(string message, Exception inner) : base(message, inner)
        {
        }

        protected UnexpectedStreamEndException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}