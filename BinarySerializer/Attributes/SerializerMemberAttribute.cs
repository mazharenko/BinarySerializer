using System;
using BinarySerializer.Stream;

namespace BinarySerializer.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class SerializerMemberAttribute : Attribute
    {
        public int Id { get; }

        public SerializerMemberAttribute(int id)
        {
            if (id <= 0 || id == Constants.MemberEndMark)
                throw new ArgumentOutOfRangeException(nameof(id));
            Id = id;
        }
    }
}