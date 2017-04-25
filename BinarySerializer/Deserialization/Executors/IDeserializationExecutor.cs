using BinarySerializer.Adapters;

namespace BinarySerializer.Deserialization.Executors
{
    public interface IDeserializationExecutor
    {
        bool GetIsApplicable(ContractMemberAdapter member, DeserializationContext context);
        void Execute(ContractMemberAdapter member, DeserializationContext context);
    }
}