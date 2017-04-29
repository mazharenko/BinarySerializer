using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BinarySerializer.Adapters;
using BinarySerializer.Extensions;
using BinarySerializer.Serialization.Entries;

namespace BinarySerializer.Serialization.Providers
{
    internal class ListStreamEntriesProvider : IStreamEntriesProvider
    {
        public bool GetIsApplicable(ContractMemberAdapter memberAdapter, SerializationContext serializationContext)
        {
            return memberAdapter.Type.GetIListImlementaionElementType() != null;
        }

        public IEnumerable<ISerializationStreamEntry> Provide(ContractMemberAdapter memberAdapter,
            SerializationContext serializationContext)
        {
            var elementType = memberAdapter.Type.GetIListImlementaionElementType();
            var list = (IList) memberAdapter.GetValue();

            var complex = serializationContext.FindConverter(elementType) == null;

            if (!(memberAdapter is ContractSingleObjectAdapter))
                yield return new MemberHeaderEntry(memberAdapter.Id);

            foreach (var innerEntry in complex
                ? ProvideComplex(list, serializationContext)
                : ProvideSimple(list, elementType))
            {
                yield return innerEntry;
            }

            if (!(memberAdapter is ContractSingleObjectAdapter) && complex)
                yield return new MemberEndingEntry();
        }

        private static IEnumerable<ISerializationStreamEntry> ProvideComplex(IEnumerable elements,
            SerializationContext serializationContext)
        {
            return elements.Cast<object>()
                .SelectMany(element =>
                {
                    var serializationStreamEntries = new ContractGraphReader().CollectMembers(new ObjectAdapter(element)).Children
                        .SelectMany(innerMember => serializationContext.GetStreamEntriesProvider(innerMember)
                            .Provide(innerMember, serializationContext))
                            .ToList();
                    return new MemberHeaderEntry(Constants.ListElementMark).AsEnumerable()
                        .Concat(
                            serializationStreamEntries
                        )
                        .Concat(new MemberEndingEntry().AsEnumerable());
                });
        }

        private static IEnumerable<ISerializationStreamEntry> ProvideSimple(ICollection elements, Type elementType)
        {
            return new ConvertationEntry(typeof(int), elements.Count).AsEnumerable()
                .Concat(elements.Cast<object>().Select(element => new ConvertationEntry(elementType, element)));
        }
    }
}