using System.Collections.Generic;
using BinarySerializer.Attributes;

namespace BinarySerializer.UnitTests.Contracts
{
    public class ListComplexObject
    {
        [SerializerMember(701)]
        public List<int> ListInt { get; set; }

        [SerializerMember(702)]

        public int[] ArrayInt { get; set; }

        [SerializerMember(703)]
        public List<ListComplexObject> ListComplex { get; set; }

        [SerializerMember(704)]
        public ListComplexObject[] ArrayComplex { get; set; }
    }
}