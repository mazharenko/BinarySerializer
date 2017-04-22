using BinarySerializer.Attributes;

namespace BinarySerializer.UnitTests.Contracts
{
    public class BooleanObject
    {
        [SerializerMember(1)]
        public bool Boolean { get; set; }

        [SerializerMember(2)]
        public bool BooleanField;
    }
}