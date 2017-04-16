using NUnit.Framework;

namespace BinarySerializer.UnitTests.ConverterTests
{
    public class UniversalConverterTestCase<T> : TestCaseData
    {
        public T Source { get; }
        public byte[] Expected { get; }

        public UniversalConverterTestCase(T source, byte[] expected, string key) : base(source, expected)
        {
            Source = source;
            Expected = expected;
            TestName = $"Test{key}Converter({source})";
        }
    }
}