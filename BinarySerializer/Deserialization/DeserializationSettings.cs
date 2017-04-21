using BinarySerializer.Base;
using BinarySerializer.Deserialization.Stream;

namespace BinarySerializer.Deserialization
{
    public class DeserializationSettings : SerializationSettingsBase
    {
        public DeserializationSettings()
        {
            StreamReader = new DeserializationStreamReader();
        }
        public IDeserializationStreamReader StreamReader { get; set; }
    }
}