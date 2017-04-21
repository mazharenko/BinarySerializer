namespace BinarySerializer.Serialization.Entries
{
    internal class MemberEndingEntry : ISerializationStreamEntry
    {
        protected bool Equals(MemberEndingEntry other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((MemberEndingEntry) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}