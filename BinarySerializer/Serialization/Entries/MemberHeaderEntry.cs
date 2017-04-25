namespace BinarySerializer.Serialization.Entries
{
    internal class MemberHeaderEntry : ISerializationStreamEntry
    {
        public int Id { get; }

        public MemberHeaderEntry(int id)
        {
            Id = id;
        }

        protected bool Equals(MemberHeaderEntry other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((MemberHeaderEntry) obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override string ToString()
        {
            return $"header/{Id}";
        }
    }
}