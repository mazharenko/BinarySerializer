
using BinarySerializer.Converters.Integer;

namespace BinarySerializer.UnitTests.ConverterTests.Cases
{
    public class IntConverterTestCase : BaseConverterTestCase<int>
    {
        public IntConverterTestCase(int source, byte[] bytes) : base(source, bytes, typeof(IntConverter))
        {
        }

        protected override string Key => "Int";
    }
}