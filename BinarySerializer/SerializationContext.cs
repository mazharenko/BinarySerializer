using System;
using System.Collections.Generic;
using System.IO;
using BinarySerializer.Converters;
using BinarySerializer.Stream.Entries;
using BinarySerializer.Stream.Providing;

namespace BinarySerializer
{
// root adapter

    public class SerializationContext
    {
        public SerializationContext(SerializationSettings settings, System.IO.Stream destinationStream)
        {
            Settings = settings;
            DestinationStream = destinationStream;
        }

        public SerializationSettings Settings { get; }
        public System.IO.Stream DestinationStream { get; }

        public IContractStreamEntriesProvider GetStreamEntriesProvider(ContractMemberAdapter memberAdapter)
        {
            return Settings.EntryProviderRegistry.GetProvider(memberAdapter, this);
        }

        public void WriteStreamEntry(ISerializationStreamEntry entry)
        {
            Settings.StreamWriter.Write(entry, this);
        }

        public IConverter FindConverter(Type type)
        {
            return Settings.Converters.Find(type);
        }
    }
}