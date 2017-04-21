using BinarySerializer.Serialization.Entries;

namespace BinarySerializer.Serialization.Stream
{
    public interface ISerializationStreamWriter
    {
        void Write(ISerializationStreamEntry entry, SerializationContext context);
    }
}