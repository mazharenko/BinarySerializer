using System.IO;

namespace BinarySerializer.Converters.Integer
{
    internal class IntConverter : SignedIntegerConverter<int>
    {
        protected override void WriteInternal(int source, Stream stream)
        {
            WriteLong(source, stream);
        }

        protected override int ReadInternal(Stream stream)
        {
            return (int) ReadLong(stream);
        }
    }
}