namespace BinarySerializer.Converters.Integer
{
    internal class IntConverter : SignedIntegerConverter<int>
    {
        protected override void WriteInternal(int source, System.IO.Stream stream)
        {
            WriteLong(source, stream);
        }

        protected override int ReadInternal(System.IO.Stream stream)
        {
            return (int) ReadLong(stream);
        }
    }
}