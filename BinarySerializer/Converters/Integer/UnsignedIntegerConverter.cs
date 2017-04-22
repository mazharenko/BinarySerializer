using System.IO;
using BinarySerializer.Exceptions;

namespace BinarySerializer.Converters.Integer
{
    internal abstract class UnsignedIntegerConverter<T> : IntegerConverter<T>
    {
        protected void WriteULong(ulong source, Stream stream)
        {
            Write(source, false, stream);
        }

        protected ulong ReadULong(Stream stream)
        {
            bool negative;
            var result = Read(stream, out negative);
            if (negative)
                throw new StreamReaderException("Unsigned integer was expected, but a negative number mark has been read.");
            return result;
        }
    }
}