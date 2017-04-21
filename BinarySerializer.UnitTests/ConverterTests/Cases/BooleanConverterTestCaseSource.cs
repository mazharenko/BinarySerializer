using System.Collections;

namespace BinarySerializer.UnitTests.ConverterTests.Cases
{
    public class BooleanConverterTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            const string key = "Bool";
            yield return new UniversalConverterTestCase<bool>(true, new byte[] {0xFF}, key);
            yield return new UniversalConverterTestCase<bool>(false, new byte[] {0x00}, key);
        }
    }
}