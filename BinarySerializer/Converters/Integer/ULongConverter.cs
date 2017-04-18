namespace BinarySerializer.Converters.Integer
{
    internal class ULongConverter : UnsignedIntegerConverter<ulong>
    {
        protected override void WriteInternal(ulong source, System.IO.Stream stream)
        {
            Write(source, stream);
        }
    }
}