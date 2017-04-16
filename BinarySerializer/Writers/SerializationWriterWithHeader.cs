namespace BinarySerializer.Writers
{
    internal abstract class SerializationWriterWithHeader : ISerializationWriter
    {
        public void Write(ContractMemberAdapter memberAdapter, SerializationContext serializationContext)
        {
            serializationContext.Settings.Converters.Find(memberAdapter.Id.GetType())
                .Convert(memberAdapter.Id, serializationContext.DestinationStream);

            WriteBody(memberAdapter, serializationContext);
        }

        protected abstract void WriteBody(ContractMemberAdapter memberAdapter, SerializationContext serializationContext);
    }
}