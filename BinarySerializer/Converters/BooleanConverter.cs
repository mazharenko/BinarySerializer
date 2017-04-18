namespace BinarySerializer.Converters
{
    internal class BooleanConverter : Converter<bool>
    {
        protected override void WriteInternal(bool source, System.IO.Stream stream)
        {
            stream.WriteByte((byte) (source ? 0xFF : 0x00));
        }
    }
}