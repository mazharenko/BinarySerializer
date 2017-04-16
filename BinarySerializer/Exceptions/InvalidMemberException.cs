using System;
using System.Runtime.Serialization;

namespace BinarySerializer.Exceptions
{
    [Serializable]
    public class InvalidMemberException : Exception
    {
        public InvalidMemberException(ContractMemberAdapter memberAdapter) : this(
            $"Unable to determine a writer for {memberAdapter.Id}:{memberAdapter.Name}")
        {
        }

        public InvalidMemberException(string message) : base(message)
        {
        }

        protected InvalidMemberException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}