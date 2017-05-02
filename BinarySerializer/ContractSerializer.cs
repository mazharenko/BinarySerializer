using System;
using System.IO;
using System.Linq;
using BinarySerializer.Adapters;
using BinarySerializer.Deserialization;
using BinarySerializer.Extensions;
using BinarySerializer.Serialization;

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
            var member = new ContractGraphReader().CollectMembers(contract.GetType(), contract);

            context.GetStreamEntriesProvider(member)
                .Provide(member, context)
                .ForEach(context.WriteStreamEntry);
        }


        public static object Deserialize(Type type, byte[] source)
        {
            using (var stream = new MemoryStream(source))
            {
                return Deserialize(type, stream);
            }
        }

        public static object Deserialize(Type type, Stream source)
        {
            return Deserialize(type, source, new DeserializationSettings());
        }

        public static object Deserialize(Type type, Stream source, DeserializationSettings settings)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            var context = new DeserializationContext(settings, source);

            var objectAdapter = new ObjectAdapter(type);
            var members = new ContractGraphReader().CollectMembers(objectAdapter);

            settings.StreamReader.Read(/*objectAdapter, */members, context);
            return objectAdapter.GetValue();
        }

        public static T Deserialize<T>(byte[] source)
        {
            return (T) Deserialize(typeof(T), source);
        }

        public static T Deserialize<T>(Stream source)
        {
            return (T) Deserialize(typeof(T), source);
        }

        public static T Deserialize<T>(Stream source, DeserializationSettings settings)
        {
            return (T) Deserialize(typeof(T), source, settings);
        }
    }
}