namespace BinarySerializer.Converters.Integer
{
    // todo: конвертер через конвертер
    internal class IntConverter : SignedIntegerConverter<int>
    {
        protected override void WriteInternal(int source, System.IO.Stream stream)
        {
            Write(source, stream);
        }
    }
}