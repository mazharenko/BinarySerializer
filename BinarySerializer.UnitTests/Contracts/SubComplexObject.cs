using BinarySerializer.Attributes;

namespace BinarySerializer.UnitTests.Contracts
{
    public class SubComplexObject
    {
        [SerializerMember(10)]
        public BooleanObject Boolean { get; set; }

        [SerializerMember(7)]
        public int Integer { get; set; }
    }
}