using BinarySerializer.Attributes;

namespace BinarySerializer.UnitTests.Contracts
{
    public class SubComplexObject
    {
        [SerializerMember(10)]
        public BooleanObject Boolean { get; set; }

        [SerializerMember(7)]
        public int Integer { get; set; }

        protected bool Equals(SubComplexObject other)
        {
            return Equals(Boolean, other.Boolean) && Integer == other.Integer;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((SubComplexObject) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Boolean != null ? Boolean.GetHashCode() : 0) * 397) ^ Integer;
            }
        }
    }
}