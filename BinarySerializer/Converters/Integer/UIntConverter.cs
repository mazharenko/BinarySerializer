namespace BinarySerializer.Converters.Integer
{
    internal class UIntConverter : UnsignedIntegerConverter<uint>
    {
        protected override void WriteInternal(uint source, System.IO.Stream stream)
        {
            WriteULong(source, stream);
        }

        protected override uint ReadInternal(System.IO.Stream stream)
        {
            return (uint) ReadULong(stream);
        }
    }
}