using BinarySerializer.Attributes;

namespace BinarySerializer.UnitTests.Contracts
{
    public class ComplexObject
    {
        [SerializerMember(2)]
        public SubComplexObject SubComplexObject;

        public int IgnoredInt { get; set; }

        protected bool Equals(ComplexObject other)
        {
            return Equals(SubComplexObject, other.SubComplexObject) && IgnoredInt == other.IgnoredInt;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ComplexObject) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((SubComplexObject != null ? SubComplexObject.GetHashCode() : 0) * 397) ^ IgnoredInt;
            }
        }
    }
}