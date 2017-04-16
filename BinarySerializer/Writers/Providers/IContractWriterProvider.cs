namespace BinarySerializer.Writers.Providers
{
    internal interface IContractWriterProvider
    {
        bool GetIsApplicable(ContractMemberAdapter memberAdapter, SerializationContext serializationContext);
        ISerializationWriter Provide();
    }
}