using System;
using BinarySerializer.Exceptions;

namespace BinarySerializer.Converters
{
    public abstract class Converter<T> : IConverter
    {
        public Type Type => typeof(T);

        public void Write(object source, System.IO.Stream stream)
        {
            if (!(source is T))
                throw new ArgumentException($"Object of type {Type} was expected");
            WriteInternal((T)source, stream);
        }

        public object Read(System.IO.Stream stream)
        {
            return ReadInternal(stream);
        }

        protected static byte[] ReadBytes(System.IO.Stream stream, int count)
        {
            var buffer = new byte[count];
            var bytesRead = stream.Read(buffer, 0, count);
            if (bytesRead != count)
                throw new StreamReaderException("Unexpected end of stream");
            return buffer;
        }

        protected abstract void WriteInternal(T source, System.IO.Stream stream);
        protected abstract T ReadInternal(System.IO.Stream stream);
    }
}