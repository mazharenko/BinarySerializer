namespace BinarySerializer.Converters.Integer
{
    internal class LongConverter : SignedIntegerConverter<long>
    {
        protected override void WriteInternal(long source, System.IO.Stream stream)
        {
            Write(source, stream);
        }
    }
}