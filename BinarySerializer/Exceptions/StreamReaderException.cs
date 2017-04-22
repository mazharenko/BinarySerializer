using System;
using System.Runtime.Serialization;

namespace BinarySerializer.Exceptions
{
    [Serializable]
    public class StreamReaderException : Exception
    {
        public StreamReaderException() : this("An error has occured during the reading from the stream")
        {
        }

        public StreamReaderException(string message) : base(message)
        {
        }

        public StreamReaderException(string message, Exception inner) : base(message, inner)
        {
        }

        protected StreamReaderException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}