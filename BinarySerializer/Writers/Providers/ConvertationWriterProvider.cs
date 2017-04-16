namespace BinarySerializer.Writers.Providers
{
    internal class ConvertationWriterProvider : IContractWriterProvider
    {
        public bool GetIsApplicable(ContractMemberAdapter memberAdapter, SerializationContext serializationContext)
        {
            return serializationContext.Settings.Converters.Find(memberAdapter.Type) != null;
        }

        public ISerializationWriter Provide()
        {
            return new ConvertationWriter();
        }
    }
}