using System;
using BinarySerializer.Converters;

namespace BinarySerializer.Base
{
    public abstract class SerializationContextBase
    {
        protected SerializationContextBase(SerializationSettingsBase settings, System.IO.Stream stream)
        {
            Stream = stream;
            Settings = settings;
        }

        public SerializationSettingsBase Settings { get; }

        public System.IO.Stream Stream { get; }

        public IConverter FindConverter(Type type)
        {
            return Settings.Converters.Find(type);
        }
    }
}