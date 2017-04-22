using BinarySerializer.Converters;

namespace BinarySerializer.UnitTests.ConverterTests.Cases
{
    public class ByteConverterTestCase : BaseConverterTestCase<byte>
    {
        public ByteConverterTestCase(byte source, byte[] bytes) : base(source, bytes, typeof(ByteConverter))
        {
        }

        protected override string Key => "Byte";
    }
}