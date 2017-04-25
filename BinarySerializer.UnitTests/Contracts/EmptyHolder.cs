using BinarySerializer.Attributes;

namespace BinarySerializer.UnitTests.Contracts
{
    public class EmptyHolder
    {
        [SerializerMember(1)]
        public Empty Empty = new Empty();
    }
}