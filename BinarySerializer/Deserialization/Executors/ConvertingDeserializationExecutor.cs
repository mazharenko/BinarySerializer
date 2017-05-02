using BinarySerializer.Adapters;

namespace BinarySerializer.Deserialization.Executors
{
    public class ConvertingDeserializationExecutor : IDeserializationExecutor
    {
        public bool GetIsApplicable(ContractMemberAdapter member, DeserializationContext context)
        {
            return context.FindConverter(member.Type) != null;
        }

        public void Execute(ContractMemberAdapter member, DeserializationContext context)
        {
            var converter = context.FindConverter(member.Type);
            member.SetValue(converter.Read(context.Stream).ExtractValue());
        }
    }
}