﻿using System;
using System.Runtime.Serialization;

namespace BinarySerializer.Exceptions
{
    [Serializable]
    public class StreamReaderException : Exception
    {
        public StreamReaderException()
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