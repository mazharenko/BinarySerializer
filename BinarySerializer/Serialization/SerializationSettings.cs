using BinarySerializer.Base;
using BinarySerializer.Serialization.Stream;

namespace BinarySerializer.Serialization
{
    public class SerializationSettings : SerializationSettingsBase
    {
        public SerializationSettings()
        {
            StreamWriter = new SerializationStreamWriter();
            EntryProviderRegistry = new StreamEntriesProviderRegistry();
        }

        public ISerializationStreamWriter StreamWriter { get; set; }
        public IStreamEntriesProviderRegistry EntryProviderRegistry { get; set; }
    }
}