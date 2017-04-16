using System.IO;

namespace BinarySerializer.Writers.Converters.Integer
{
    internal class ULongConverter : UnsignedIntegerConverter<ulong>
    {
        protected override void WriteInternal(ulong source, Stream stream)
        {
            Write(source, stream);
        }
    }
}