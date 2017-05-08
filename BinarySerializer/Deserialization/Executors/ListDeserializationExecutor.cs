using System;
using System.Collections;
using System.Collections.Generic;
using BinarySerializer.Adapters;
using BinarySerializer.Exceptions;
using BinarySerializer.Extensions;

namespace BinarySerializer.Deserialization.Executors
{
    public class ListDeserializationExecutor : IDeserializationExecutor
    {
        public bool GetIsApplicable(ContractMemberAdapter member, DeserializationContext context)
        {
            return member.Type.GetIListImlementaionElementType() != null;
        }

        public void Execute(ContractMemberAdapter member, DeserializationContext context)
        {
            var elementType = member.Type.GetIListImlementaionElementType();
            var list = (IList) Activator.CreateInstance(typeof(List<>).MakeGenericType(elementType));
            var complex = context.GetConverter(elementType) == null;

            if (complex)
                ExecuteComplex(member, list, context);
            else
                ExecuteSimple(member, list, context);

            member.SetValue(list);
        }

        private void ExecuteComplex(ContractMemberAdapter member, IList list, DeserializationContext context)
        {
            var elementType = member.Type.GetIListImlementaionElementType();
            while (true)
            {
                object idObject;

                if (!context.GetConverter(typeof(int)).Read(context.Stream).ExtractValue(out idObject))
                    if (member is ContractRootAdapter)
                        break;
                    else
                        throw new UnexpectedStreamEndException();

                if ((int)idObject == Constants.MemberEndMark)
                    break;
                if ((int)idObject != Constants.ListElementMark)
                    throw new StreamReaderException("An unexpected member id appeared in the input stream");

                var objectAdapter = new ObjectAdapter(elementType.CreateContract());
                var collected = new ContractGraphReader().CollectMembers(objectAdapter);

                context.GetDeserializationExecutor(collected).Execute(collected, context);

                list.Add(objectAdapter.GetValue());
            }
        }

        private void ExecuteSimple(ContractMemberAdapter member, IList list, DeserializationContext context)
        {
            var elementType = member.Type.GetIListImlementaionElementType();
            var count = (int) context.GetConverter(typeof(int)).Read(context.Stream).ExtractValue();
            while (count-- > 0)
            {
                list.Add(context.GetConverter(elementType).Read(context.Stream).ExtractValue());
            }
        }

    }
}