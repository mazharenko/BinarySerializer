using System.IO;

namespace BinarySerializer.Converters.Integer
{
    internal class UIntConverter : UnsignedIntegerConverter<uint>
    {
        protected override void WriteInternal(uint source, Stream stream)
        {
            WriteULong(source, stream);
        }

        protected override uint ReadInternal(Stream stream)
        {
            return (uint) ReadULong(stream);
        }
    }
}