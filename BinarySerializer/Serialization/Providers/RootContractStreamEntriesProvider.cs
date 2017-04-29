using System.Collections.Generic;
using System.Linq;
using BinarySerializer.Adapters;
using BinarySerializer.Serialization.Entries;

namespace BinarySerializer.Serialization.Providers
{
    internal class RootContractStreamEntriesProvider : IStreamEntriesProvider
    {
        public bool GetIsApplicable(ContractMemberAdapter memberAdapter, SerializationContext serializationContext)
        {
            return memberAdapter is ContractRootAdapter && memberAdapter.Children != null && memberAdapter.Children.Any();
        }

        public IEnumerable<ISerializationStreamEntry> Provide(ContractMemberAdapter memberAdapter,
            SerializationContext serializationContext)
        {
            return memberAdapter.Children.SelectMany(c => serializationContext.GetStreamEntriesProvider(c)
                .Provide(c, serializationContext));
        }
    }
}