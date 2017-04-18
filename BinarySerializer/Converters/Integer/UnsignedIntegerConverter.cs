namespace BinarySerializer.Converters.Integer
{
    internal abstract class UnsignedIntegerConverter<T> : IntegerConverter<T>
    {
        protected void Write(ulong source, System.IO.Stream stream)
        {
            Write(source, false, stream);
        }
    }
}