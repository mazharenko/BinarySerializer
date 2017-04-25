using BinarySerializer.Base;
using BinarySerializer.Deserialization.Stream;

namespace BinarySerializer.Deserialization
{
    public class DeserializationSettings : SerializationSettingsBase
    {
        public DeserializationSettings()
        {
            StreamReader = new DeserializationStreamReader();
            ExecutorRegistry = new DeserializationExecutorRegistry();
        }
        public IDeserializationStreamReader StreamReader { get; internal set; }
        public IDeserializationExecutorRegistry ExecutorRegistry { get; internal set; }
    }
}