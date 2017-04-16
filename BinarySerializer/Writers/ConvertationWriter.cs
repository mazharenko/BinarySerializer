namespace BinarySerializer.Writers
{
    internal class ConvertationWriter : SerializationWriterWithHeader
    {
        protected override void WriteBody(ContractMemberAdapter memberAdapter, SerializationContext serializationContext)
        {
            serializationContext.Settings.Converters.Find(memberAdapter.Type)
                .Convert(memberAdapter.GetValue(), serializationContext.DestinationStream);
        }
    }
}