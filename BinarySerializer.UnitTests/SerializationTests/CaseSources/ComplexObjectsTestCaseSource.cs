using System.Collections;
using BinarySerializer.UnitTests.SerializationTests.Cases;
using Contracts;

namespace BinarySerializer.UnitTests.SerializationTests.CaseSources
{
    public class ComplexObjectsTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield break;
        }

        public static IEnumerable GetSerializationOnlyCases()
        {
            yield return new SerializationTestCase(new ComplexObject
            {
                IgnoredInt = 30,
                SubComplexObject = new SubComplexObject
                {
                    Boolean = new BooleanObject
                    {
                        Boolean = true,
                        BooleanField = true
                    },
                    Integer = -421
                }
            }, new byte[] {0x82, 0x8A, 0x81, 0xFF, 0x82, 0xFF, 0x80, 0x87, 0x12, 0x01, 0xA4, 0x80}, "ComplexObject1");

            yield return new SerializationTestCase(new BooleanObject
            {
                Boolean = true,
                BooleanField = false
            }, new byte[] {0x81, 0xFF}, "ComplexObject2");
        }
        
        public static IEnumerable GetDeserializationOnlyCases()
        {
            yield return new SerializationTestCase(new ComplexObject
            {
                IgnoredInt = 0,
                SubComplexObject = new SubComplexObject
                {
                    Boolean = new BooleanObject
                    {
                        Boolean = true,
                        BooleanField = true
                    },
                    Integer = -421
                }
            }, new byte[] {0x82, 0x8A, 0x81, 0xFF, 0x82, 0xFF, 0x80, 0x87, 0x12, 0x01, 0xA4, 0x80}, "ComplexObject1De");
        }
    }
}