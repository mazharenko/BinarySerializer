using NUnit.Framework;

namespace BinarySerializer.UnitTests.ConverterTests.Cases
{
    public class UniversalConverterTestCase<T> : TestCaseData
    {
        public T Object { get; }
        public byte[] Bytes { get; }

        public UniversalConverterTestCase(T @object, byte[] bytes, string key) : base(@object, bytes)
        {
            Object = @object;
            Bytes = bytes;
            TestName = $"Test{key}Converter({@object})";
        }
    }
}