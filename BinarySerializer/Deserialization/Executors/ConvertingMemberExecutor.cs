using System;
using System.Collections.Generic;
using System.Linq;
using BinarySerializer.Adapters;
using BinarySerializer.Exceptions;

namespace BinarySerializer.Deserialization.Executors
{
    public class ConvertingDeserializationExecutor : MemberExecutorBase, IDeserializationExecutor
    {
        public bool GetIsApplicable(ContractMemberAdapter member, DeserializationContext context)
        {
            return context.FindConverter(member.Type) != null;
        }

        public void Execute(ContractMemberAdapter member, DeserializationContext context)
        {
            var converter = context.FindConverter(member.Type);
            member.SetValue(ExtractValueFromReadResult(converter.Read(context.Stream)));
        }
    }
}