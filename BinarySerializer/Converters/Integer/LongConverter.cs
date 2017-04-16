using System.IO;

namespace BinarySerializer.Converters.Integer
{
    internal class LongConverter : SignedIntegerConverter<long>
    {
        protected override void WriteInternal(long source, Stream stream)
        {
            Write(source, stream);
        }
    }
}