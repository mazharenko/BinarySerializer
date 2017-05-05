using System.Collections.Generic;
using System.Linq;
using BinarySerializer.Adapters;
using BinarySerializer.Exceptions;
using BinarySerializer.Serialization.Providers;

namespace BinarySerializer.Serialization.Stream
{
    internal class StreamEntriesProviderRegistry : IStreamEntriesProviderRegistry
    {
        protected readonly List<IStreamEntriesProvider> Providers = new List<IStreamEntriesProvider>
        {
            new DefaultMemberStreamEntriesProvider(),
            new SingleObjectStreamEntitiesProvider(),
            new ConvertingMemberStreamEntriesProvider(),
            new ListStreamEntriesProvider(),
            new RootContractStreamEntriesProvider(),
            new ContractStreamEntriesProvider(),
        };

        public IStreamEntriesProvider GetProvider(ContractMemberAdapter memberAdapter,
            SerializationContext serializationContext)
        {
            var provider = Providers.FirstOrDefault(s => s.GetIsApplicable(memberAdapter, serializationContext));
            if (provider == null)
                throw new InvalidMemberException(memberAdapter);
            return provider;
        }
    }
}