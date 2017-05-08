using BinarySerializer.Adapters;

namespace BinarySerializer.Deserialization.Executors
{
    public class ConvertingDeserializationExecutor : IDeserializationExecutor
    {
        public bool GetIsApplicable(ContractMemberAdapter member, DeserializationContext context)
        {
            return context.GetConverter(member.Type) != null;
        }

        public void Execute(ContractMemberAdapter member, DeserializationContext context)
        {
            var converter = context.GetConverter(member.Type);
            member.SetValue(converter.Read(context.Stream).ExtractValue());
        }
    }
}