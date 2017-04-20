using BinarySerializer.Stream;

namespace BinarySerializer
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

    public class DeserializationSettings : SerializationSettingsBase
    {
        public DeserializationSettings()
        {
            StreamReader = new DeserializationStreamReader();
        }
        public IDeserializationStreamReader StreamReader { get; set; }
    }
}