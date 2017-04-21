using System.Collections.Generic;
using BinarySerializer.Adapters;
using BinarySerializer.Serialization.Entries;

namespace BinarySerializer.Serialization.Providing
{
    internal class ConvertingMemberStreamEntriesProvider : IContractStreamEntriesProvider
    {
        public bool GetIsApplicable(ContractMemberAdapter memberAdapter, SerializationContext serializationContext)
        {
            return serializationContext.FindConverter(memberAdapter.Type) != null;
        }

        public IEnumerable<ISerializationStreamEntry> Provide(ContractMemberAdapter memberAdapter, SerializationContext serializationContext)
        {
            yield return new MemberHeaderEntry(memberAdapter.Id);
            yield return new ConvertationEntry(memberAdapter.Type, memberAdapter.GetValue());
        }
    }
}