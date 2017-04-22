using BinarySerializer.Converters.Integer;

namespace BinarySerializer.UnitTests.ConverterTests.Cases
{
    public class LongConverterTestCase : BaseConverterTestCase<long>
    {
        public LongConverterTestCase(long source, byte[] bytes) : base(source, bytes, typeof(LongConverter))
        {
        }

        protected override string Key => "Long";
    }
}