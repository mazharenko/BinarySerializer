using System;

namespace BinarySerializer.Stream.Entries
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
    }
}