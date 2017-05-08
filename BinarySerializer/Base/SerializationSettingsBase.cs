using System.Collections.Generic;
using BinarySerializer.Converters;
using BinarySerializer.Converters.Integer;
using BinarySerializer.Converters.Registry;

namespace BinarySerializer.Base
{
    public abstract class SerializationSettingsBase
    {
        protected SerializationSettingsBase()
        {
            Converters = new ConverterRegistry();
        }
        public IConverterRegistry Converters { get; }
    }
}