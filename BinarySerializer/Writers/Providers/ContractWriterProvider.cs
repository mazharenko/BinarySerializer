using System.Security.AccessControl;

namespace BinarySerializer.Writers.Providers
{
    internal class ContractWriterProvider : IContractWriterProvider
    {
        public bool GetIsApplicable(ContractMemberAdapter memberAdapter, SerializationContext serializationContext)
        {
            return memberAdapter.Children != null;
        }

        public ISerializationWriter Provide()
        {
            return new ContractWriter();
        }
    }
}