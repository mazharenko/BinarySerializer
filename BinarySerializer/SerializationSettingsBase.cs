using System.Collections.Generic;
using BinarySerializer.Converters;
using BinarySerializer.Converters.Integer;

namespace BinarySerializer
{
    public abstract class SerializationSettingsBase
    {
        protected SerializationSettingsBase()
        {
            // TODO: на добавление проверять, не контракт ли это с нашей т.з.
            Converters = new ConvertersCollection(new List<IConverter>
            {
                new BooleanConverter(),
                new IntConverter(),
                new LongConverter(),
                new UIntConverter(),
                new ULongConverter()
            });
        }
        public ConvertersCollection Converters { get; }
    }
}