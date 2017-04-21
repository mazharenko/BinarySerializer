using System.Collections.Generic;
using System.Linq;
using BinarySerializer.Adapters;
using BinarySerializer.Extensions;
using BinarySerializer.Serialization.Entries;

namespace BinarySerializer.Serialization.Providing
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