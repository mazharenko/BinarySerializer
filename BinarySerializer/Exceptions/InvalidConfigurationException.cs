using System;
using System.Runtime.Serialization;

namespace BinarySerializer.Exceptions
{
    [Serializable]
    public class InvalidConfigurationException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public InvalidConfigurationException() : this("Invalid configuration detected")
        {
        }

        public InvalidConfigurationException(string message) : base(message)
        {
        }

        public InvalidConfigurationException(string message, Exception inner) : base(message, inner)
        {
        }

        protected InvalidConfigurationException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}