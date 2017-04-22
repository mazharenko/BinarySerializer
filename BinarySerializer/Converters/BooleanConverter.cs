using System;
using System.IO;
using System.Linq;
using System.Text;

namespace BinarySerializer.Converters
{
    internal class BooleanConverter : Converter<bool>
    {
        protected override void WriteInternal(bool source, Stream stream)
        {
            stream.WriteByte((byte) (source ? 0xFF : 0x00));
        }

        protected override bool ReadInternal(Stream stream)
        {
            return ReadBytes(stream, 1).Single() > 0;
        }
    }

    internal class StringConverter : Converter<string>
    {
        protected override void WriteInternal(string source, Stream stream)
        {
            var bytes = Encoding.UTF8.GetBytes(source);
            stream.Write(bytes, 0, bytes.Length);
            stream.WriteByte(0x00);
        }

        protected override string ReadInternal(Stream stream)
        {
            var bytes = new byte[100];
            var bytesCount = 0;
            while (true)
            {
                if (bytesCount >= bytes.Length)
                    Array.Resize(ref bytes, bytes.Length + 100);
                ReadBytes(stream, 1).CopyTo(bytes, bytesCount);
                bytesCount++;

                if (bytes[bytesCount - 1] == 0x00)
                    break;
            }

            return Encoding.UTF8.GetString(bytes, 0, bytesCount - 1);
        }
    }
}