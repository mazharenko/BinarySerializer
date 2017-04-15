using System;
using System.Runtime.Serialization;

namespace BinarySerializer.Exceptions
{
    [Serializable]
    public class DuplicateMemberIdsException : InvalidConfigurationException
    {
        public Type Type { get; }

        public DuplicateMemberIdsException(Type type) : this(type, $"Contract {type} has duplicate member ids")
        {
        }

        public DuplicateMemberIdsException(Type type, string message) : base(message)
        {
            Type = type;
        }

        protected DuplicateMemberIdsException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}