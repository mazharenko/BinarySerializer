namespace BinarySerializer.UnitTests.ConverterTests.Cases
{
    public class IntConverterTestCase : BaseConverterTestCase<int>
    {
        public IntConverterTestCase(int source, byte[] bytes) : base(source, bytes)
        {
        }

        protected override string Key => "Int";
    }
}