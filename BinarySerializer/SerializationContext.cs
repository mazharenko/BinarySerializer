using System;
using System.IO;
using BinarySerializer.Writers;

namespace BinarySerializer
{
// root adapter

    public class SerializationContext
    {
        public SerializationContext(SerializationSettings settings, Stream destinationStream)
        {
            Settings = settings;
            DestinationStream = destinationStream;
        }

        public SerializationSettings Settings { get; }
        public Stream DestinationStream { get; }

        public ISerializationWriter ProvideWriter(ContractMemberAdapter memberAdapter)
        {
            return Settings.WriterFactory.CreateWriter(memberAdapter, this);
        }
    }
}