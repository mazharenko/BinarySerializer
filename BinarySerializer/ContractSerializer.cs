using System;
using System.IO;
using System.Linq;

namespace BinarySerializer
{
    public static class ContractSerializer
    {
        public static byte[] Serialize(object contract)
        {
            if (contract == null) throw new ArgumentNullException(nameof(contract));
            using (var stream = new MemoryStream())
            {
                Serialize(contract, stream);
                return stream.ToArray();
            }
        }

        public static void Serialize(object contract, System.IO.Stream destination)
        {
            Serialize(contract, destination, new SerializationSettings());
        }

        public static void Serialize(object contract, System.IO.Stream destination, SerializationSettings settings)
        {
            if (contract == null) throw new ArgumentNullException(nameof(contract));
            if (destination == null) throw new ArgumentNullException(nameof(destination));
            var context = new SerializationContext(settings, destination);
            new ContractReader(context).CollectMembers(contract.GetType(), contract)
                .SelectMany(contractMemberAdapter => context.GetStreamEntriesProvider(contractMemberAdapter)
                    .Provide(contractMemberAdapter, context))
                .ForEach(context.WriteStreamEntry);
        }
    }
}