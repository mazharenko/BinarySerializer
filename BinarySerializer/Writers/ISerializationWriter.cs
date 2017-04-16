using System.IO;

namespace BinarySerializer.Writers
{
    public interface ISerializationWriter
    {
        void Write(ContractMemberAdapter memberAdapter, SerializationContext serializationContext);
    }
}