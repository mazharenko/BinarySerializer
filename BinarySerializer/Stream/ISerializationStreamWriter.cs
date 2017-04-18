using BinarySerializer.Stream.Entries;

namespace BinarySerializer.Stream
{
    public interface ISerializationStreamWriter
    {
        void Write(ISerializationStreamEntry entry, SerializationContext context);
    }
}