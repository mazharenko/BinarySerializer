using System.Collections;
using BinarySerializer.UnitTests.Contracts;
using BinarySerializer.UnitTests.SerializationTests.Cases;

namespace BinarySerializer.UnitTests.SerializationTests.CaseSources
{
    public class EmptyObjectsTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new SerializationTestCase(new Empty(), new byte[] { }, "Empty");

            yield return new SerializationTestCase(new EmptyHolder(), new byte[] {0xE4, 0x80}, "EmptyHolder");

            yield return new SerializationTestCase(new EmptyHolder
            {
                SubHolder = new EmptySubHolder()
            }, new byte[] {0xE5, 0xE4, 0x80, 0x80, 0xE4, 0x80}, "EmptyHolderDouble");
        }

        public static IEnumerable GetSerializationOnlyCases()
        {
            yield return new SerializationTestCase(new EmptyHolder
            {
                Empty = null
            }, new byte[] { }, "EmptyHolderNull");

            yield return new SerializationTestCase(new EmptyHolder
            {
                SubHolder = new EmptySubHolder
                {
                    Empty = null
                }
            }, new byte[] {0xE5, 0x80, 0xE4, 0x80}, "EmptyHolderDoubleNull");
        }

        public static IEnumerable GetDeserializationOnlyCases()
        {
            // input stream doesn't provide any information about Empty property value,
            // so it is considered to have null value. but it gets its not-null value
            // during an EmptyHolder class instance instantiating, so it is not null
            // after a deserialization. as designed.
            yield return new SerializationTestCase(new EmptyHolder
            {
                //Empty = null
            }, new byte[] { }, "EmptyHolderNullDe");

            // input stream doesn't provide any information about Empty property value,
            // so it is considered to have null value. but it gets its not-null value
            // during an EmptyHolder class instance instantiating, so it is not null
            // after a deserialization. as designed.
            yield return new SerializationTestCase(new EmptyHolder
            {
                SubHolder = new EmptySubHolder
                {
                    //Empty = null
                }
            }, new byte[] {0xE5, 0x80, 0xE4, 0x80}, "EmptyHolderDoubleNullDe");
        }
    }
}