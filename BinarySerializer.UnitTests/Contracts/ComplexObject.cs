using BinarySerializer.Attributes;

namespace BinarySerializer.UnitTests.Contracts
{
    public class ComplexObject
    {
        [SerializerMember(2)]
        public SubComplexObject SubComplexObject;

        public int IgnoredInt { get; set; }
    }
}