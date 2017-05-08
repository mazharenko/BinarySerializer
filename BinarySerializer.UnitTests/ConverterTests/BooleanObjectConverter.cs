using BinarySerializer.Converters.Base;
using BinarySerializer.UnitTests.Contracts;

namespace BinarySerializer.UnitTests.ConverterTests
{
    public class BooleanObjectConverter : SubConverter<BooleanObject, int>
    {
        protected override int WriteInternal(BooleanObject source)
        {
            return (source.Boolean ? 1 : 0) << 1
                   | (source.BooleanField ? 1 : 0);
        }

        protected override BooleanObject ReadInternal(int source)
        {
            return new BooleanObject
            {
                Boolean = (source & 2) != 0,
                BooleanField = (source & 1) != 0
            };
        }
    }
}