using BinarySerializer.Adapters;
using BinarySerializer.Serialization.Providing;

namespace BinarySerializer.Serialization.Stream
{
    public interface IStreamEntriesProviderRegistry
    {
        IContractStreamEntriesProvider GetProvider(ContractMemberAdapter memberAdapter,
            SerializationContext serializationContext);
    }
}