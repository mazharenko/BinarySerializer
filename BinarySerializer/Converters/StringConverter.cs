using System;
using System.IO;
using System.Text;

namespace BinarySerializer.Converters
{
    internal class StringConverter : Converter<string>
    {
        protected override void WriteInternal(string source, Stream stream)
        {
            var zeroIndex = source.IndexOf('\0');
            if (zeroIndex != -1)
                source = source.Substring(0, zeroIndex);
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