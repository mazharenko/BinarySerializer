using System.Collections.Generic;
using BinarySerializer.Converters;
using BinarySerializer.Converters.Integer;
using BinarySerializer.Stream;

namespace BinarySerializer
{
    public class SerializationSettings
    {
        public SerializationSettings()
        {
            Converters = new ConvertersCollection(new List<IConverter>
            {
                new BooleanConverter(),
                new IntConverter(),
                new LongConverter(),
                new UIntConverter(),
                new ULongConverter()
            });

            StreamWriter = new SerializationStreamWriter();
            EntryProviderRegistry = new StreamEntriesProviderRegistry();
        }

        public ConvertersCollection Converters { get; }
        public ISerializationStreamWriter StreamWriter { get; set; }
        public IStreamEntriesProviderRegistry EntryProviderRegistry { get; set; }
    }
}