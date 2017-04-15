using System.IO;

namespace BinarySerializer.Writers.Converters
{
    internal class BooleanConverter
    {
        private readonly bool _source;

        public BooleanConverter(bool source)
        {
            _source = source;
        }

        public void Write(Stream stream)
        {
            stream.WriteByte((byte) (_source ? 0xFF : 0x00));
        }
    }
}