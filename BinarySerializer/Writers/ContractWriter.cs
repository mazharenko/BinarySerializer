namespace BinarySerializer.Writers
{
    internal class ContractWriter : SerializationWriterWithHeader
    {
        protected override void WriteBody(ContractMemberAdapter memberAdapter, SerializationContext serializationContext)
        {
            foreach (var contractMemberAdapter in memberAdapter.Children)
            {
                serializationContext.ProvideWriter(contractMemberAdapter).Write(contractMemberAdapter, serializationContext);
            }

            serializationContext.DestinationStream.WriteByte(0x00);
        }
    }
}