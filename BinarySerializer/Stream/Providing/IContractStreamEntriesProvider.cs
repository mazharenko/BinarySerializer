using System.Collections.Generic;
using BinarySerializer.Stream.Entries;

namespace BinarySerializer.Stream.Providing
{
    public interface IContractStreamEntriesProvider
    {
        IEnumerable<ISerializationStreamEntry> Provide(ContractMemberAdapter memberAdapter, SerializationContext serializationContext);
        bool GetIsApplicable(ContractMemberAdapter memberAdapter, SerializationContext serializationContext);
    }
}