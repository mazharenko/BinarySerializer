using System;

namespace BinarySerializer.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class SerializerMemberAttribute : Attribute
    {
        public int Id { get; }

        public SerializerMemberAttribute(int id)
        {
            Id = id;
        }
    }
}