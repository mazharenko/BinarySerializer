using BinarySerializer.Adapters;

namespace BinarySerializer.Deserialization.Stream
{
    public class DeserializationStreamReader : IDeserializationStreamReader
    {
        public void Read(ContractMemberAdapter members, DeserializationContext context)
        {
            context.GetDeserializationExecutor(members).Execute(members, context);
        }
    }
}