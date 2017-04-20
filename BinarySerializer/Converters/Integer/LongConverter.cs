namespace BinarySerializer.Converters.Integer
{
    internal class LongConverter : SignedIntegerConverter<long>
    {
        protected override void WriteInternal(long source, System.IO.Stream stream)
        {
            WriteLong(source, stream);
        }

        protected override long ReadInternal(System.IO.Stream stream)
        {
            return ReadLong(stream);
        }
    }
}