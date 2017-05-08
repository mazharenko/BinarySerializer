using System;

namespace BinarySerializer.Converters.Base
{
    public abstract class SubConverter<T, TSub> : ISubConverter
    {
        public Type SubType => typeof(TSub);
        public Type Type => typeof(T); // byte[]

        public object Write(object source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (!(source is T))
                throw new ArgumentException($"Object of type {Type} was expected");
            return WriteInternal((T) source);
        }

        public object Read(object source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            return ReadInternal((TSub)source);
        }

        protected abstract TSub WriteInternal(T source);

        protected abstract T ReadInternal(TSub source);
    }
}