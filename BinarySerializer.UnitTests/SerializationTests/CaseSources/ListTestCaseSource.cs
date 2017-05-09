using System.Collections;
using System.Collections.Generic;
using BinarySerializer.UnitTests.SerializationTests.Cases;
using Contracts;

namespace BinarySerializer.UnitTests.SerializationTests.CaseSources
{
    public class ListTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new SerializationTestCase(new List<int>
            {
                17,
                94,
                255
            }, new byte[] {0x83, 0x91, 0xDE, 0x01, 0xFF}, "ListInt");

            yield return new SerializationTestCase(new List<ListComplexObject>
            {
                new ListComplexObject
                {
                    ListInt = new List<int>
                    {
                        4,
                        9
                    }
                },
                new ListComplexObject
                {
                    ListInt = new List<int>
                    {
                        7,
                        0,
                        341
                    }
                },
                new ListComplexObject
                {
                    ListInt = new List<int>
                    {
                        -123,
                        41
                    }
                }
            }, new byte[]
            {
                0x81, 0x02, 0x02, 0xBD, 0x82, 0x84, 0x89, 0x80,
                0x81, 0x02, 0x02, 0xBD, 0x83, 0x87, 0x80, 0x02, 0x01, 0x55, 0x80,
                0x81, 0x02, 0x02, 0xBD, 0x82, 0x11, 0x7A, 0xA9, 0x80
            }, "ListCombined");
        }
    }
}