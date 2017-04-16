using System.IO;

namespace BinarySerializer.Writers.Converters.Integer
{
    internal class IntConverter : SignedIntegerConverter<int>
    {
        protected override void WriteInternal(int source, Stream stream)
        {
            Write(source, stream);
        }
    }
}