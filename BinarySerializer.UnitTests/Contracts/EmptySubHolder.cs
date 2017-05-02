using BinarySerializer.Attributes;

namespace BinarySerializer.UnitTests.Contracts
{
    public class EmptySubHolder
    {
        [SerializerMember(100)]
        public Empty Empty = new Empty();
    }
}