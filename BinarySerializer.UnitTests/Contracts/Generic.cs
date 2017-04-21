using BinarySerializer.Attributes;

namespace BinarySerializer.UnitTests.Contracts
{
    public class Generic<T>
    {
        [SerializerMember(1)]
        public T Parameter { get; set; } 
    }
}