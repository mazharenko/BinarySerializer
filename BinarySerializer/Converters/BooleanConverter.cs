using System.Linq;

namespace BinarySerializer.Converters
{
    internal class BooleanConverter : Converter<bool>
    {
        protected override void WriteInternal(bool source, System.IO.Stream stream)
        {
            stream.WriteByte((byte) (source ? 0xFF : 0x00));
        }

        protected override bool ReadInternal(System.IO.Stream stream)
        {
            return ReadBytes(stream, 1).Single() > 0;
        }
    }
}