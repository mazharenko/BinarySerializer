using System.Runtime.Serialization;
using BinarySerializer.Attributes;

namespace BinarySerializer.UnitTests.Contracts
{
    public class Class1
    {
        [SerializerMember(1)]
        public bool Boolean { get; set; }

        [SerializerMember(2)]
        public bool BooleanField;
    }

    public class ComplexObject
    {
        [SerializerMember(1)]
        public string String { get; set; }
        [SerializerMember(2)]
        public ComplexObject2 ComplexObject2;

        public int IgnoredInt { get; set; }
    }

    public class ComplexObject2
    {
        [SerializerMember(10)]
        public Class1 Class1 { get; set; }
    }
}