using System.Collections;
using BinarySerializer.Converters;
using BinarySerializer.UnitTests.ConverterTests.Cases;

namespace BinarySerializer.UnitTests.ConverterTests.CaseSources
{
    public class BooleanConverterTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            const string key = "Bool";
            yield return new UniversalConverterTestCase<bool>(true, new byte[] {0xFF}, key, typeof(BooleanConverter));
            yield return new UniversalConverterTestCase<bool>(false, new byte[] {0x00}, key, typeof(BooleanConverter));
        }
    }
}