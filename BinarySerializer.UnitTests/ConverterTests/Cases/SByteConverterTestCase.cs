using BinarySerializer.Converters;

namespace BinarySerializer.UnitTests.ConverterTests.Cases
{
    public class SByteConverterTestCase : BaseConverterTestCase<sbyte>
    {
        public SByteConverterTestCase(sbyte source, byte[] bytes) : base(source, bytes, typeof(SByteConverter))
        {
        }

        protected override string Key => "SByte";
    }
}