using System;

namespace BinarySerializer.Serialization.Entries
{
    internal class ConvertationEntry : ISerializationStreamEntry
    {
        public Type Type { get; }
        public object Value { get; }

        public ConvertationEntry(Type type, object value)
        {
            Type = type;
            Value = value;
        }

        protected bool Equals(ConvertationEntry other)
        {
            return Type == other.Type && Equals(Value, other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((ConvertationEntry) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Type != null ? Type.GetHashCode() : 0) * 397) ^ (Value != null ? Value.GetHashCode() : 0);
            }
        }
    }
}