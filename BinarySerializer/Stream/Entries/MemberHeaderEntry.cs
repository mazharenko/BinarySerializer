namespace BinarySerializer.Stream.Entries
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