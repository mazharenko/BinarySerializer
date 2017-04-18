using System;

namespace BinarySerializer.Converters.Integer
{
    internal abstract class SignedIntegerConverter<T> : IntegerConverter<T>
    {
        protected void Write(long source, System.IO.Stream stream)
        {
            var casted = unchecked ((ulong)(source < 0 ? Math.Abs(source + 1) : source));
            Write(casted, source < 0, stream);
        }
    }
}