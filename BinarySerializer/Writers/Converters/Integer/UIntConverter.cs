using System.IO;

namespace BinarySerializer.Writers.Converters.Integer
{
    internal class UIntConverter : UnsignedIntegerConverter<uint>
    {
        protected override void WriteInternal(uint source, Stream stream)
        {
            Write(source, stream);
        }
    }
}