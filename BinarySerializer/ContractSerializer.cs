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
            Serialize(contract, destination, new ContractSerializationSettings());
        }

        public static void Serialize(object contract, Stream destination, ContractSerializationSettings settings)
        {
            if (contract == null) throw new ArgumentNullException(nameof(contract));
            if (destination == null) throw new ArgumentNullException(nameof(destination));
            var d = new ContractReader(settings).CollectMembers(contract.GetType(), contract);
        }
    }
}