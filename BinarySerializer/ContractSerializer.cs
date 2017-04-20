using System;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;

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
            new ContractReader().CollectMembers(contract.GetType(), contract)
                .SelectMany(
                    contractMemberAdapter => context.GetStreamEntriesProvider(contractMemberAdapter)
                        .Provide(contractMemberAdapter, context))
                .ForEach(context.WriteStreamEntry);
        }

        public static T Deserialize<T>(byte[] source)
        {
            using (var stream = new MemoryStream(source))
            {
                return Deserialize<T>(stream);
            }
        }

        public static T Deserialize<T>(System.IO.Stream source)
        {
            return Deserialize<T>(source, new DeserializationSettings());
        }

        public static T Deserialize<T>(System.IO.Stream source, DeserializationSettings settings)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            var context = new DeserializationContext(settings, source);

            var objectAdapter = new ObjectAdapter(typeof(T));
            var members = new ContractReader().CollectMembers(objectAdapter);

            settings.StreamReader.Read(objectAdapter, members, context);
            return (T)objectAdapter.GetValue();
        }
    }
}