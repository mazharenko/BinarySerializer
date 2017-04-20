using System.Linq;

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
    // [size] bytes - value, exact if non-negative, |x|-1 if negative. obviously, skipped for -1.
    internal abstract class IntegerConverter<T> : Converter<T>
    {
        private const byte Size = 8;

        protected void Write(ulong source, bool negative, System.IO.Stream stream)
        {
            if (!negative && source >> 7 == 0)
                WriteShort(source, stream);
            else
                WriteLong(source, negative, stream);
        }

        private static void WriteShort(ulong source, System.IO.Stream stream)
        {
            stream.WriteByte((byte) (0x80 + source));
        }

        private static void WriteLong(ulong source, bool negative, System.IO.Stream stream)
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

        // if strats from 1
        // non-negative and 7 following bits were enough
        //
        // ELSE
        //
        // negative if 0001, non-negative if 0000
        // 4 bits - size, how many bytes was enough to store value, 0 for -1
        // [size] bytes - value, exact if non-negative, |x|-1 if negative. obviously, skipped for -1.
        protected ulong Read(System.IO.Stream stream, out bool negative)
        {
            negative = false;
            var firstByte = ReadBytes(stream, 1).Single();
            if ((firstByte & 0x80) != 0)
                return (ulong) (firstByte & 0x7F);

            negative = (firstByte & 0xF0) != 0;
            var size = firstByte & 0x0F;

            var leftBytes = ReadBytes(stream, size);
            return leftBytes.Aggregate(0UL, (res, b) => res << 8 | b);
        }
    }
}