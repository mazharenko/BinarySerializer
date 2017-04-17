using System.IO;

namespace BinarySerializer.Converters.Integer
{
    // if non-negative and 7 bits is enough
    // 1
    // 7 bits - value
    //
    // ELSE
    //
    // 0001 if negative, 0000 if non-negative
    // 4 bits - size, how many bytes is enough to store value, 0 for -1
    // [size] bytes - value, exact is non-negative, |x|-1 if negative. obviously, skipped for -1.
    internal abstract class IntegerConverter<T> : Converter<T>
    {
        private const byte Size = 8;

        protected void Write(ulong source, bool negative, Stream stream)
        {
            if (!negative && source >> 7 == 0)
                WriteShort(source, stream);
            else
                WriteLong(source, negative, stream);
        }

        private static void WriteShort(ulong source, Stream stream)
        {
            stream.WriteByte((byte) (0x80 + source));
        }

        private static void WriteLong(ulong source, bool negative, Stream stream)
        {
            var offset = Size;
            var sizeFixed = false;
            while (offset > 0)
            {
                var higherByte = source >> ((offset - 1) * 8);
                if (higherByte == 0)
                {
                    offset--;
                    continue;
                }
                if (!sizeFixed)
                {
                    var signSizeByte = ((negative ? 1 : 0) << 4) + offset;
                    stream.WriteByte((byte) signSizeByte);
                    sizeFixed = true;
                }
                stream.WriteByte((byte) higherByte);
                offset--;
            }
            if (!sizeFixed) //-1 or 0
            {
                stream.WriteByte((byte) ((negative ? 1 : 0) << 4));
            }
        }
    }
}