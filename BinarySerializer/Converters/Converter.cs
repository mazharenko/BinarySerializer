using System;

namespace BinarySerializer.Converters
{
    public abstract class Converter<T> : IConverter
    {
        public Type Type => typeof(T);

        public void Convert(object source, System.IO.Stream stream)
        {
            if (!(source is T))
                throw new ArgumentException($"Object of type {Type} was expected");
            WriteInternal((T)source, stream);
        }

        protected abstract void WriteInternal(T source, System.IO.Stream stream);
    }
}