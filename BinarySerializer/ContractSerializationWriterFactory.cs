using System.Collections.Generic;
using System.Linq;
using BinarySerializer.Exceptions;
using BinarySerializer.Stream.Entries;
using BinarySerializer.Stream.Providing;

namespace BinarySerializer
{
    internal class StreamEntriesProviderRegistry : IStreamEntriesProviderRegistry
    {
        protected readonly List<IContractStreamEntriesProvider> Providers = new List<IContractStreamEntriesProvider>
        {
            new ConvertingMemberStreamEntriesProvider(),
            new ContractStreamEntriesProvider()
        };

        public IContractStreamEntriesProvider GetProvider(ContractMemberAdapter memberAdapter,
            SerializationContext serializationContext)
        {
            var provider = Providers.FirstOrDefault(s => s.GetIsApplicable(memberAdapter, serializationContext));
            if (provider == null)
                throw new InvalidMemberException(memberAdapter);
            return provider;
        }
    }
}