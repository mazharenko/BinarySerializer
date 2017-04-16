namespace BinarySerializer.UnitTests.ConverterTests
{
    public class IntConverterTestCase : BaseConverterTestCase<int>
    {
        public IntConverterTestCase(int source, byte[] expected) : base(source, expected)
        {
        }

        protected override string Key => "Int";
    }
}