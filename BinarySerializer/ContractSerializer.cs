using System;
using System.IO;

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

        public static void Serialize(object contract, Stream destination)
        {
            Serialize(contract, destination, new SerializationSettings());
        }

        public static void Serialize(object contract, Stream destination, SerializationSettings settings)
        {
            if (contract == null) throw new ArgumentNullException(nameof(contract));
            if (destination == null) throw new ArgumentNullException(nameof(destination));
            var context = new SerializationContext(settings, destination);
            foreach (var contractMemberAdapter in new ContractReader(context).CollectMembers(contract.GetType(), contract))
            {
                context.ProvideWriter(contractMemberAdapter).Write(contractMemberAdapter, context);
            }
        }
    }
}