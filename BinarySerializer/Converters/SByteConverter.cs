using System.IO;
using System.Linq;

namespace BinarySerializer.Converters
{
    // конвертер-шлюз!!??
    // или енумы все-таки через provider...
    internal class SByteConverter : Converter<sbyte>
    {
        protected override void WriteInternal(sbyte source, Stream stream)
        {
            stream.WriteByte((byte)source);
        }

        protected override sbyte ReadInternal(Stream stream)
        {
            return (sbyte)ReadBytes(stream, 1).Single();
        }
    }
}