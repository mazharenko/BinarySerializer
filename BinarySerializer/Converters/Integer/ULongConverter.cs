using System.IO;

namespace BinarySerializer.Converters.Integer
{
    internal class ULongConverter : UnsignedIntegerConverter<ulong>
    {
        protected override void WriteInternal(ulong source, Stream stream)
        {
            WriteULong(source, stream);
        }

        protected override ulong ReadInternal(Stream stream)
        {
            return ReadULong(stream);
        }
    }
}