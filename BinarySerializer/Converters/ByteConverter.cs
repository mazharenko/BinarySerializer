using System.IO;
using System.Linq;
using BinarySerializer.Converters.Base;

namespace BinarySerializer.Converters
{
    internal class ByteConverter : Converter<byte>
    {
        protected override void WriteInternal(byte source, Stream stream)
        {
            stream.WriteByte(source);
        }

        protected override byte ReadInternal(Stream stream)
        {
            return ReadBytes(stream, 1).Single();
        }
    }
}