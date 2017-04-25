using System;
using System.Collections.Generic;
using System.Linq;
using BinarySerializer.Adapters;
using BinarySerializer.Converters;
using BinarySerializer.Exceptions;

namespace BinarySerializer.Deserialization.Stream
{
    public class DeserializationStreamReader : IDeserializationStreamReader
    {
        public void Read(ObjectAdapter objectAdapter, ICollection<ContractMemberAdapter> members, DeserializationContext context)
        {
            var singleAdapter = members.OfType<ContractSingleObjectAdapter>().SingleOrDefault();
            if (singleAdapter != null)
            {
                ReadSingle(singleAdapter, context);
            }
            else
            {
                ReadMultipleRoot(objectAdapter, members, context);
            }
        }

        private static object ExtractValueFromReadResult(ConverterReadResult readResult, out bool streamEndReached)
        {
            streamEndReached = readResult.StreamEndReached;
            return readResult.Value;
        }

        private static object ExtractValueFromReadResult(ConverterReadResult readResult)
        {
            bool streamEndReached;
            var result = ExtractValueFromReadResult(readResult, out streamEndReached);
            if (streamEndReached)
                throw new UnexpectedStreamEndException();
            return result;
        }

        private void ReadSingle(ContractSingleObjectAdapter singleObject, DeserializationContext context)
        {
            if (ContractIsCreatable(singleObject.Type))
                singleObject.SetValue(CreateContract(singleObject.Type));

            context.GetDeserializationExecutor(singleObject)?.Execute(singleObject, context);
        }

        private void ReadMultipleRoot(ObjectAdapter objectAdapter, ICollection<ContractMemberAdapter> members, DeserializationContext context)
        {
            objectAdapter.SetValue(CreateContract(objectAdapter.Type));
            while (true)
            {
                bool streamEnd;
                var idObject = ExtractValueFromReadResult(context.FindConverter(typeof(int)).Read(context.Stream),
                    out streamEnd);
                if (streamEnd)
                    break;
                ReadMultipleMemberValue((int)idObject, members, context);
            }
        }

        private void ReadMultipleSubObject(ICollection<ContractMemberAdapter> members, DeserializationContext context)
        {
            while (true)
            {
                var id = (int)ExtractValueFromReadResult(context.FindConverter(typeof(int)).Read(context.Stream));
                if (id == Constants.MemberEndMark)
                    break;
                ReadMultipleMemberValue(id, members, context);
            }
        }

        private void ReadMultipleMemberValue(int id, IEnumerable<ContractMemberAdapter> members, DeserializationContext context)
        {
            var member = members.FirstOrDefault(m => m.Id == id);
            if (member == null)
                throw new StreamReaderException("An unexpected member id appeared in the input stream");

            if (ContractIsCreatable(member.Type))
                member.SetValue(CreateContract(member.Type));

            if (member.Children.Any())
            {
                ReadMultipleSubObject(member.Children, context);
            }
            else
            {
                context.GetDeserializationExecutor(member)?.Execute(member, context);
            }
        }

        private static object CreateContract(Type type)
        {
            if (!ContractIsCreatable(type))
                throw new InvalidConfigurationException($"The specified type can't be either instantiated or converted - {type}");

            return Activator.CreateInstance(type);
        }

        private static bool ContractIsCreatable(Type type)
        {
            return type.GetConstructor(new Type[0]) != null;
        }
    }
}