using BinarySerializer.Adapters;
using BinarySerializer.Extensions;

namespace BinarySerializer.Deserialization.Executors
{
    public class ConvertingDeserializationExecutor : MemberExecutorBase
    {
        public override bool GetIsApplicable(ContractMemberAdapter member, DeserializationContext context)
        {
            return context.FindConverter(member.Type) != null;
        }

        public override void Execute(ContractMemberAdapter member, DeserializationContext context)
        {
            var converter = context.FindConverter(member.Type);
            member.SetValue(ExtractValueFromReadResult(converter.Read(context.Stream)));
        }
    }

}