namespace BinarySerializer.UnitTests.ConverterTests.Cases
{
    public class LongConverterTestCase : BaseConverterTestCase<long>
    {
        public LongConverterTestCase(long source, byte[] bytes) : base(source, bytes)
        {
        }

        protected override string Key => "Long";
    }
}