namespace BinarySerializer.Serialization.Entries
{
    internal class MemberHeaderEntry : ISerializationStreamEntry
    {
        public int Id { get; }

        public MemberHeaderEntry(int id)
        {
            Id = id;
        }
    }
}