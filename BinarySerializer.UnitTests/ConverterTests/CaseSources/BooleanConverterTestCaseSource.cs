using System;
using System.Collections;
using BinarySerializer.Converters;
using BinarySerializer.UnitTests.ConverterTests.Cases;

namespace BinarySerializer.UnitTests.ConverterTests.CaseSources
{
    public class BooleanConverterTestCaseSource : IEnumerable
    {
        private static readonly Type ConverterType = typeof(BooleanConverter);
        private const string Key = "Bool";

        public IEnumerator GetEnumerator()
        {
            yield return new UniversalConverterTestCase<bool, byte[]>(true, new byte[] {0xFF}, Key, ConverterType);
            yield return new UniversalConverterTestCase<bool, byte[]>(false, new byte[] {0x00}, Key, ConverterType);
        }
    }
}