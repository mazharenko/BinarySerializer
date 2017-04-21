using System;
using System.Collections.Generic;
using System.Linq;
using BinarySerializer.Adapters;
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
                ReadRoot(objectAdapter, members, context);
            }
        }

        private void ReadSingle(ContractSingleObjectAdapter singleObject, DeserializationContext context)
        {
            var converter = context.FindConverter(singleObject.Type);
            if (converter != null)
                singleObject.SetValue(converter.Read(context.Stream));
            else if (ContractIsCreatable(singleObject.Type))
                singleObject.SetValue(CreateContract(singleObject.Type));
            else
                throw new UnknownTypeException(singleObject.Type);
        }

        // TODO: refactor!!
        private void ReadRoot(ObjectAdapter objectAdapter, ICollection<ContractMemberAdapter> members, DeserializationContext context)
        {
            objectAdapter.SetValue(CreateContract(objectAdapter.Type));
            while (context.Stream.Position < context.Stream.Length)
            {
                var id = (int)context.FindConverter(typeof(int)).Read(context.Stream);
                var member = members.FirstOrDefault(m => m.Id == id);
                if (member == null)
                    throw new StreamReaderException("An unexpected member id appeared in the input stream");

                var converter = context.FindConverter(member.Type);
                if (converter == null)
                {
                    member.SetValue(CreateContract(member.Type));
                    ReadSubObject(member.Children, context);
                }
                else
                {
                    member.SetValue(converter.Read(context.Stream));
                }
            }
        }

        private void ReadSubObject(ICollection<ContractMemberAdapter> members, DeserializationContext context)
        {
            while (true)
            {
                var id = (int)context.FindConverter(typeof(int)).Read(context.Stream);
                if (id == Constants.MemberEndMark)
                    break;

                var member = members.FirstOrDefault(m => m.Id == id);
                if (member == null)
                    throw new StreamReaderException("An unexpected member id appeared in the input stream");

                var converter = context.FindConverter(member.Type);
                if (converter == null)
                {
                    member.SetValue(CreateContract(member.Type));
                    ReadSubObject(member.Children, context);
                }
                else
                {
                    member.SetValue(converter.Read(context.Stream));
                }
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