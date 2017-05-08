using System.Collections;
using BinarySerializer.UnitTests.SerializationTests.Cases;

namespace BinarySerializer.UnitTests.SerializationTests.CaseSources
{
    public class SingleObjectsTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new SerializationTestCase(45, new byte[] {0xAD}, "Integer");
            yield return new SerializationTestCase("Foo © bar 𝌆 baz ☃ qux", new byte[]
            {
                0x46, 0x6F, 0x6F, 0x20, 0xC2, 0xA9, 0x20, 0x62, 0x61, 0x72, 0x20, 0xF0, 0x9D, 0x8C, 0x86, 0x20,
                0x62, 0x61, 0x7A, 0x20, 0xE2, 0x98, 0x83, 0x20, 0x71, 0x75, 0x78, 0x00
            }, "Integer");
        }
    }
}