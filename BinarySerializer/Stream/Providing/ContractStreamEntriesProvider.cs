using System.Collections.Generic;
using System.Linq;
using BinarySerializer.Stream.Entries;

namespace BinarySerializer.Stream.Providing
{
    internal class ContractStreamEntriesProvider : IContractStreamEntriesProvider
    {
        public bool GetIsApplicable(ContractMemberAdapter memberAdapter, SerializationContext serializationContext)
        {
            return memberAdapter.Children != null;
        }

        public IEnumerable<ISerializationStreamEntry> Provide(ContractMemberAdapter memberAdapter,
            SerializationContext serializationContext)
        {
            return new MemberHeaderEntry(memberAdapter.Id).AsEnumerable()
                .Concat(
                    memberAdapter.Children.SelectMany(c => serializationContext.GetStreamEntriesProvider(c)
                        .Provide(c, serializationContext))
                )
                .Concat(new MemberEndingEntry().AsEnumerable());
        }
    }
}