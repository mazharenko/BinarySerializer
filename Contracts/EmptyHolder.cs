using BinarySerializer.Attributes;

namespace Contracts
{
    public class EmptyHolder
    {
        [SerializerMember(100)] public Empty Empty = new Empty();

        [SerializerMember(101)]
        public EmptySubHolder SubHolder { get; set; }

        protected bool Equals(EmptyHolder other)
        {
            return Equals(Empty, other.Empty) && Equals(SubHolder, other.SubHolder);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((EmptyHolder) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Empty != null ? Empty.GetHashCode() : 0) * 397) ^
                       (SubHolder != null ? SubHolder.GetHashCode() : 0);
            }
        }
    }
}