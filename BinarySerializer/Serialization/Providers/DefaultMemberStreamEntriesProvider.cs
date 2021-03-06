using System.Collections.Generic;
using BinarySerializer.Adapters;
using BinarySerializer.Extensions;
using BinarySerializer.Serialization.Entries;

namespace BinarySerializer.Serialization.Providers
{
    internal class DefaultMemberStreamEntriesProvider : IStreamEntriesProvider
    {
        public bool GetIsApplicable(ContractMemberAdapter memberAdapter, SerializationContext serializationContext)
        {
            return Equals(memberAdapter.GetValue(), memberAdapter.Type.Default());
        }

        public IEnumerable<ISerializationStreamEntry> Provide(ContractMemberAdapter memberAdapter,
            SerializationContext serializationContext)
        {
            yield break;
        }
    }
}