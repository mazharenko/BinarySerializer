using System;
using System.Collections.Generic;
using System.Linq;
using BinarySerializer.Adapters;
using BinarySerializer.Serialization.Entries;

namespace BinarySerializer.Serialization.Providers
{
    internal class EmptyContractStreamEntriesProvider : IStreamEntriesProvider
    {
        public bool GetIsApplicable(ContractMemberAdapter memberAdapter, SerializationContext serializationContext)
        {
            return // memberAdapter is ContractSingleObjectAdapter &&
                   memberAdapter.Type.GetConstructor(new Type[0]) != null && !(memberAdapter.Children?.Any() ?? false);
        }

        public IEnumerable<ISerializationStreamEntry> Provide(ContractMemberAdapter memberAdapter, SerializationContext serializationContext)
        {
            yield return new MemberHeaderEntry(memberAdapter.Id);
            yield return new MemberEndingEntry();
        }
    }
}