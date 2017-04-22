using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BinarySerializer.UnitTests.ConverterTests.Cases;

namespace BinarySerializer.UnitTests.ConverterTests.CaseSources
{
    public class IntegerConverterTestCaseSource
    {
        public static IEnumerable GetInt32Cases()
        {
            yield return new IntConverterTestCase(1, new byte[] {0x81});
            yield return new IntConverterTestCase(9, new byte[] {0x89});
            yield return new IntConverterTestCase(127, new byte[] {0xFF});
            yield return new IntConverterTestCase(128, new byte[] {0x01, 0x80});
            yield return new IntConverterTestCase(1000, new byte[] {0x02, 0x03, 0xE8});
            yield return new IntConverterTestCase(int.MaxValue, new byte[] {0x04, 0x7F, 0xFF, 0xFF, 0xFF});
            yield return new IntConverterTestCase(int.MinValue, new byte[] {0x14, 0x7F, 0xFF, 0xFF, 0xFF});
            yield return new IntConverterTestCase(-1000, new byte[] {0x12, 0x03, 0xE7});
            yield return new IntConverterTestCase(-1, new byte[] {0x10});
            yield return new IntConverterTestCase(-2, new byte[] {0x11, 0x01});
            yield return new IntConverterTestCase(0, new byte[] {0x80});
        }

        public static IEnumerable GetLongCases()
        {
            return GetInt32Cases()
                .OfType<IntConverterTestCase>()
                .Select(c => new LongConverterTestCase(c.Object, c.Bytes))
                .Concat(new List<LongConverterTestCase>
                {
                    new LongConverterTestCase(long.MaxValue,
                        new byte[] {0x08, 0x7F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF}),
                    new LongConverterTestCase(long.MinValue,
                        new byte[] {0x18, 0x7F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF})
                });
        }

        public static IEnumerable GetByteCases()
        {
            yield return new ByteConverterTestCase(0, new byte[] {0x00});
            yield return new ByteConverterTestCase(1, new byte[] {0x01});
            yield return new ByteConverterTestCase(9, new byte[] {0x09});
            yield return new ByteConverterTestCase(127, new byte[] {0x7F});
            yield return new ByteConverterTestCase(128, new byte[] {0x80});
            yield return new ByteConverterTestCase(129, new byte[] {0x81});
            yield return new ByteConverterTestCase(255, new byte[] {0xFF});
        }

        public static IEnumerable GetSByteCases()
        {
            yield return new SByteConverterTestCase(0, new byte[] {0x00});
            yield return new SByteConverterTestCase(1, new byte[] {0x01});
            yield return new SByteConverterTestCase(9, new byte[] {0x09});
            yield return new SByteConverterTestCase(127, new byte[] {0x7F});
            yield return new SByteConverterTestCase(-1, new byte[] {0xFF});
            yield return new SByteConverterTestCase(-2, new byte[] {0xFE});
            yield return new SByteConverterTestCase(-127, new byte[] {0x81});
            yield return new SByteConverterTestCase(-128, new byte[] {0x80});
        }
    }
}