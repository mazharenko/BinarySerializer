using System.Collections.Generic;
using BinarySerializer.Stream.Entries;
using BinarySerializer.Stream.Providing;

namespace BinarySerializer
{
    public interface IStreamEntriesProviderRegistry
    {
        IContractStreamEntriesProvider GetProvider(ContractMemberAdapter memberAdapter,
            SerializationContext serializationContext);
    }
}