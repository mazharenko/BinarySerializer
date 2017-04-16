using System.Collections.Generic;
using System.Linq;
using BinarySerializer.Exceptions;
using BinarySerializer.Writers;
using BinarySerializer.Writers.Providers;

namespace BinarySerializer
{
    internal class ContractSerializationWriterFactory : IContractSerializationWriterFactory
    {
        protected readonly List<IContractWriterProvider> ProviderSequence = new List<IContractWriterProvider>
        {
            new ConvertationWriterProvider(),
            new ContractWriterProvider()
        };

        public ISerializationWriter CreateWriter(ContractMemberAdapter memberAdapter, SerializationContext serializationContext)
        {
            var provider = ProviderSequence.FirstOrDefault(s => s.GetIsApplicable(memberAdapter, serializationContext));
            if (provider == null)
                throw new InvalidMemberException(memberAdapter);
            return provider.Provide();
        }
    }
}