using System.IO;

namespace BinarySerializer.Converters.Integer
{
    internal abstract class UnsignedIntegerConverter<T> : IntegerConverter<T>
    {
        protected void Write(ulong source, Stream stream)
        {
            Write(source, false, stream);
        }
    }
}