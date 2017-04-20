namespace BinarySerializer.Converters.Integer
{
    internal class ULongConverter : UnsignedIntegerConverter<ulong>
    {
        protected override void WriteInternal(ulong source, System.IO.Stream stream)
        {
            WriteULong(source, stream);
        }

        protected override ulong ReadInternal(System.IO.Stream stream)
        {
            return ReadULong(stream);
        }
    }
}