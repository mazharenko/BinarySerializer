using BinarySerializer.Stream.Entries;
using BinarySerializer.Stream.Providing;

namespace BinarySerializer
{
    public class SerializationContext : SerializationContextBase
    {
        // ReSharper disable once SuggestBaseTypeForParameter
        public SerializationContext(SerializationSettings settings, System.IO.Stream destinationStream) : base(settings,
            destinationStream)
        {
        }

        public new SerializationSettings Settings => (SerializationSettings) base.Settings;

        public IContractStreamEntriesProvider GetStreamEntriesProvider(ContractMemberAdapter memberAdapter)
        {
            return Settings.EntryProviderRegistry.GetProvider(memberAdapter, this);
        }

        public void WriteStreamEntry(ISerializationStreamEntry entry)
        {
            Settings.StreamWriter.Write(entry, this);
        }
    }
}