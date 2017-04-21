using System;
using System.Runtime.Serialization;
using BinarySerializer.Adapters;

namespace BinarySerializer.Exceptions
{
    [Serializable]
    public class UnknownTypeException : InvalidMemberException
    {
        public UnknownTypeException(Type type) : this($"Unable to determine a converter for {type}")
        {
        }

        public UnknownTypeException(ContractMemberAdapter memberAdapter) : this(memberAdapter.Type)
        {
        }

        public UnknownTypeException(string message) : base(message)
        {
        }

        protected UnknownTypeException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}