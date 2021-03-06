﻿using BinarySerializer.Adapters;
using BinarySerializer.Base;
using BinarySerializer.Serialization.Entries;
using BinarySerializer.Serialization.Providers;

namespace BinarySerializer.Serialization
{
    public class SerializationContext : SerializationContextBase
    {
        // ReSharper disable once SuggestBaseTypeForParameter
        public SerializationContext(SerializationSettings settings, System.IO.Stream destinationStream) : base(settings,
            destinationStream)
        {
        }

        public new SerializationSettings Settings => (SerializationSettings) base.Settings;

        public IStreamEntriesProvider GetStreamEntriesProvider(ContractMemberAdapter memberAdapter)
        {
            return Settings.EntryProviderRegistry.GetProvider(memberAdapter, this);
        }

        public void WriteStreamEntry(ISerializationStreamEntry entry)
        {
            Settings.StreamWriter.Write(entry, this);
        }
    }
}