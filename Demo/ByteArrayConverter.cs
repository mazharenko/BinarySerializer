using System;
using System.IO;
using System.Linq;
using BinarySerializer.Converters.Base;

namespace Demo
{
    public class ByteArrayConverter : Converter<byte[]>
    {
        protected override void WriteInternal(byte[] source, Stream stream)
        {
            if (source.Length > 255)
                throw new ArgumentException();
            stream.WriteByte((byte)source.Length);
            stream.Write(source, 0, source.Length);
        }

        protected override byte[] ReadInternal(Stream stream)
        {
            var count = ReadBytes(stream, 1).Single();
            return ReadBytes(stream, count);
        }
    }
}