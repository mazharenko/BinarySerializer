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
            if (contract == null) throw new ArgumentNullException(nameof(contract));
            if (destination == null) throw new ArgumentNullException(nameof(destination));
            var d = new ContractReader().CollectMembers(contract.GetType(), contract);
        }
    }
}