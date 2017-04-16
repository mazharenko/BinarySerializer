using System;
using System.Runtime.Serialization;

namespace BinarySerializer.Exceptions
{
    [Serializable]
    public class DuplicateMemberIdsException : InvalidConfigurationException
    {
        public DuplicateMemberIdsException(Type type) : this($"Contract {type} has duplicate member ids")
        {
        }

        public DuplicateMemberIdsException(string message) : base(message)
        {
        }

        protected DuplicateMemberIdsException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}