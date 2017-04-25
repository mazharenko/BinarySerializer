using BinarySerializer.Adapters;
using BinarySerializer.Deserialization.Executors;

namespace BinarySerializer.Deserialization.Stream
{
    public interface IDeserializationExecutorRegistry
    {
        IDeserializationExecutor GetExecutor(ContractMemberAdapter memberAdapter,
            DeserializationContext serializationContext);
    }
}