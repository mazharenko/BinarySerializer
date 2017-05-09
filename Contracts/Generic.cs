using BinarySerializer.Attributes;

namespace Contracts
{
    public class Generic<T>
    {
        [SerializerMember(1)]
        public T Parameter { get; set; } 
    }
}