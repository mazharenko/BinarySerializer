using BinarySerializer.Adapters;
using BinarySerializer.Serialization.Providers;

namespace BinarySerializer.Serialization.Stream
{
    public interface IStreamEntriesProviderRegistry
    {
        IStreamEntriesProvider GetProvider(ContractMemberAdapter memberAdapter,
            SerializationContext serializationContext);
    }
}