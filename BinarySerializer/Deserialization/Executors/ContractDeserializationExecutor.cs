using System.Linq;
using BinarySerializer.Adapters;
using BinarySerializer.Exceptions;
using BinarySerializer.Extensions;

namespace BinarySerializer.Deserialization.Executors
{
    public class ContractDeserializationExecutor : IDeserializationExecutor
    {
        public bool GetIsApplicable(ContractMemberAdapter member, DeserializationContext context)
        {
            return member.Type.ContractIsCreatable();//member.Children != null && member.Children.Any();
        }

        public void Execute(ContractMemberAdapter member, DeserializationContext context)
        {
            member.SetValue(member.Type.CreateContract());
            while (true)
            {
                object idObject;

                if (!context.FindConverter(typeof(int)).Read(context.Stream).ExtractValue(out idObject))
                    if (member is ContractRootAdapter)
                        break;
                    else
                        throw new UnexpectedStreamEndException();

                if ((int)idObject == Constants.MemberEndMark)
                    break;

                ReadMultipleMemberValue((int)idObject, member, context);
            }
        }

        private void ReadMultipleMemberValue(int id, ContractMemberAdapter memberParent,
            DeserializationContext context)
        {
            var member = memberParent.Children.FirstOrDefault(m => m.Id == id);
            if (member == null)
                throw new StreamReaderException("An unexpected member id appeared in the input stream");

            context.GetDeserializationExecutor(member)?.Execute(member, context);
        }

    }
}