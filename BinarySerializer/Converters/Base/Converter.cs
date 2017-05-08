using System;
using System.IO;
using BinarySerializer.Exceptions;

namespace BinarySerializer.Converters.Base
{
    public abstract class Converter<T> : IConverter
    {
        public Type Type => typeof(T);

        public void Write(object source, Stream stream)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (!(source is T))
                throw new ArgumentException($"Object of type {Type} was expected");
            WriteInternal((T) source, stream);
        }

        public ConverterReadResult Read(Stream stream)
        {
            try
            {
                return Result(ReadInternal(stream));
            }
            catch (StreamEndReachedException)
            {
                return ConverterReadResult.StreamEnd();
            }
        }

        protected static byte[] ReadBytes(Stream stream, int count)
        {
            var buffer = new byte[count];
            var bytesRead = stream.Read(buffer, 0, count);
            ProcessStreamBytesReadCount(bytesRead, count);
            return buffer;
        }

        protected static ConverterReadResult Result(object value)
        {
            return new ConverterReadResult
            {
                Value = value,
                StreamEndReached = false
            };
        }

        protected abstract void WriteInternal(T source, Stream stream);
        protected abstract T ReadInternal(Stream stream);

        private static void ProcessStreamBytesReadCount(int bytesRead, int bytesExected)
        {
            if (bytesExected == 0)
                return;
            if (bytesRead == 0)
                throw new StreamEndReachedException();
            if (bytesRead != bytesExected)
                throw new UnexpectedStreamEndException();
        }
    }
}