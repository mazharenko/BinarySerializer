using BinarySerializer.Attributes;

namespace BinarySerializer.UnitTests.Contracts
{
    public class BooleanObject
    {
        [SerializerMember(1)]
        public bool Boolean { get; set; }

        [SerializerMember(2)]
        public bool BooleanField;

        protected bool Equals(BooleanObject other)
        {
            return BooleanField == other.BooleanField && Boolean == other.Boolean;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((BooleanObject) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (BooleanField.GetHashCode() * 397) ^ Boolean.GetHashCode();
            }
        }
    }
}