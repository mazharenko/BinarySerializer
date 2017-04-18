namespace BinarySerializer.Converters.Integer
{
    internal class UIntConverter : UnsignedIntegerConverter<uint>
    {
        protected override void WriteInternal(uint source, System.IO.Stream stream)
        {
            Write(source, stream);
        }
    }
}