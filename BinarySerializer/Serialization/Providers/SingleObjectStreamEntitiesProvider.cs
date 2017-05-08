using System.Collections.Generic;
using System.Linq;
using BinarySerializer.Adapters;
using BinarySerializer.Serialization.Entries;

namespace BinarySerializer.Serialization.Providers
{
    internal class SingleObjectStreamEntitiesProvider : IStreamEntriesProvider
    {
        public bool GetIsApplicable(ContractMemberAdapter memberAdapter, SerializationContext serializationContext)
        {
            return memberAdapter is ContractSingleObjectAdapter
                   && serializationContext.GetConverter(memberAdapter.Type) != null;
        }

        public IEnumerable<ISerializationStreamEntry> Provide(ContractMemberAdapter memberAdapter,
            SerializationContext serializationContext)
        {
            yield return new ConvertationEntry(memberAdapter.Type, memberAdapter.GetValue());
        }
    }
}