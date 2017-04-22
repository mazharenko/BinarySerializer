using System;
using System.IO;
using BinarySerializer.Converters;

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

        public IConverter FindConverter(Type type)
        {
            return Settings.Converters.Find(type);
        }
    }
}