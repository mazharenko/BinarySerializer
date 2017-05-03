using System.Collections;
using BinarySerializer.UnitTests.SerializationTests.Cases;

namespace BinarySerializer.UnitTests.SerializationTests.CaseSources
{
    public class SingleObjectsTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new SerializationTestCase(45, new byte[] {0xAD}, "Integer");
        }
    }
}