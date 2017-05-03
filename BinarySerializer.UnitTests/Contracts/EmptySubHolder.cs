using BinarySerializer.Attributes;

namespace BinarySerializer.UnitTests.Contracts
{
    public class EmptySubHolder
    {
        [SerializerMember(100)] public Empty Empty = new Empty();

        protected bool Equals(EmptySubHolder other)
        {
            return Equals(Empty, other.Empty);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((EmptySubHolder) obj);
        }

        public override int GetHashCode()
        {
            return (Empty != null ? Empty.GetHashCode() : 0);
        }
    }
}