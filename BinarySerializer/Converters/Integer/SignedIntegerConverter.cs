using System;
using System.IO;

namespace BinarySerializer.Converters.Integer
{
    internal abstract class SignedIntegerConverter<T> : IntegerConverter<T>
    {
        protected void WriteLong(long source, Stream stream)
        {
            var casted = unchecked ((ulong)(source < 0 ? Math.Abs(source + 1) : source));
            Write(casted, source < 0, stream);
        }

        protected long ReadLong(Stream stream)
        {
            bool negative;
            var fromStream = Read(stream, out negative);
            if (negative)
                return -(long)fromStream - 1;
            return (long) fromStream;
        }
    }
}