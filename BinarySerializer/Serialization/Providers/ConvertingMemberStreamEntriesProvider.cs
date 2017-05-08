using System.Collections.Generic;
using BinarySerializer.Adapters;
using BinarySerializer.Serialization.Entries;

namespace BinarySerializer.Serialization.Providers
{
    internal class ConvertingMemberStreamEntriesProvider : IStreamEntriesProvider
    {
        public bool GetIsApplicable(ContractMemberAdapter memberAdapter, SerializationContext serializationContext)
        {
            return serializationContext.GetConverter(memberAdapter.Type) != null;
        }

        public IEnumerable<ISerializationStreamEntry> Provide(ContractMemberAdapter memberAdapter, SerializationContext serializationContext)
        {
            if (!(memberAdapter is ContractSingleObjectAdapter))
                yield return new MemberHeaderEntry(memberAdapter.Id);
            yield return new ConvertationEntry(memberAdapter.Type, memberAdapter.GetValue());
        }
    }
}