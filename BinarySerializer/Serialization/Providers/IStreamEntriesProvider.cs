using System.Collections.Generic;
using BinarySerializer.Adapters;
using BinarySerializer.Serialization.Entries;

namespace BinarySerializer.Serialization.Providers
{
    public interface IStreamEntriesProvider
    {
        IEnumerable<ISerializationStreamEntry> Provide(ContractMemberAdapter memberAdapter, SerializationContext serializationContext);
        bool GetIsApplicable(ContractMemberAdapter memberAdapter, SerializationContext serializationContext);
    }
}