using BinarySerializer.Writers;

namespace BinarySerializer
{
    public interface IContractSerializationWriterFactory
    {
        ISerializationWriter CreateWriter(ContractMemberAdapter memberAdapter, SerializationContext serializationContext);
    }
}