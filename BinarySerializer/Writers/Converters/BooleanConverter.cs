using System.IO;

namespace BinarySerializer.Writers.Converters
{
    internal class BooleanConverter : Converter<bool>
    {
        protected override void WriteInternal(bool source, Stream stream)
        {
            stream.WriteByte((byte) (source ? 0xFF : 0x00));
        }
    }
}