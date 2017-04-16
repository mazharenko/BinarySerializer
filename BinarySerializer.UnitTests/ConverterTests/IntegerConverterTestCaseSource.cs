using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BinarySerializer.UnitTests.ConverterTests
{
    public class IntegerConverterTestCaseSource
    {
        public static IEnumerable GetInt32Cases()
        {
            //yield return new IntegerConverterTestCase(0, new byte[] {0x00});

            yield return new IntConverterTestCase(1, new byte[] {0x01, 0x01});
            yield return new IntConverterTestCase(9, new byte[] {0x01, 0x09});
            yield return new IntConverterTestCase(1000, new byte[] {0x02, 0x03, 0xE8});
            yield return new IntConverterTestCase(int.MaxValue, new byte[] {0x04, 0x7F, 0xFF, 0xFF, 0xFF});
            yield return new IntConverterTestCase(int.MinValue, new byte[] {0x14, 0x7F, 0xFF, 0xFF, 0xFF});
            yield return new IntConverterTestCase(-1000, new byte[] {0x12, 0x03, 0xE7});
            yield return new IntConverterTestCase(-1, new byte[] {0x10});
            yield return new IntConverterTestCase(0, new byte[] {0x00});
        }

        public static IEnumerable GetLongCases()
        {
            return GetInt32Cases()
                .OfType<IntConverterTestCase>()
                .Select(c => new LongConverterTestCase(c.Source, c.Expected))
                .Concat(new List<LongConverterTestCase>
                {
                    new LongConverterTestCase(long.MaxValue, new byte[]{0x08, 0x7F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF}),
                    new LongConverterTestCase(long.MinValue, new byte[]{0x18, 0x7F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF})
                });
        }
    }
}