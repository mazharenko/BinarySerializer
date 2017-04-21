using System.Collections.Generic;
using BinarySerializer.Adapters;
using BinarySerializer.Serialization.Entries;

namespace BinarySerializer.Serialization.Providing
{
    public interface IContractStreamEntriesProvider
    {
        IEnumerable<ISerializationStreamEntry> Provide(ContractMemberAdapter memberAdapter, SerializationContext serializationContext);
        bool GetIsApplicable(ContractMemberAdapter memberAdapter, SerializationContext serializationContext);
    }
}