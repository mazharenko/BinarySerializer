using System;
using System.IO;
using BinarySerializer.Converters;
using BinarySerializer.Converters.Base;

namespace BinarySerializer.Base
{
    public abstract class SerializationContextBase
    {
        protected SerializationContextBase(SerializationSettingsBase settings, Stream stream)
        {
            Stream = stream;
            Settings = settings;
        }

        public SerializationSettingsBase Settings { get; }

        public Stream Stream { get; }

        public IConverter GetConverter(Type type)
        {
            return Settings.Converters.GetConverter(type);
        }
    }
}