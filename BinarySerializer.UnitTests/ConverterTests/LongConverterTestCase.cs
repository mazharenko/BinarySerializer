using NUnit.Framework;

namespace BinarySerializer.UnitTests.ConverterTests
{
    public class LongConverterTestCase : BaseConverterTestCase<long>
    {
        public LongConverterTestCase(long source, byte[] expected) : base(source, expected)
        {
        }

        protected override string Key => "Long";
    }
}