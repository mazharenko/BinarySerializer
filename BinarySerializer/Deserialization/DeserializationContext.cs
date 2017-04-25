using BinarySerializer.Adapters;
using BinarySerializer.Base;
using BinarySerializer.Deserialization.Executors;

namespace BinarySerializer.Deserialization
{
    public class DeserializationContext : SerializationContextBase
    {
        // ReSharper disable once SuggestBaseTypeForParameter
        public DeserializationContext(DeserializationSettings settings, System.IO.Stream stream) : base(settings, stream)
        {
        }

        public new DeserializationSettings Settings => (DeserializationSettings) base.Settings;

        public IDeserializationExecutor GetDeserializationExecutor(ContractMemberAdapter memberAdapter)
        {
            return Settings.ExecutorRegistry.GetExecutor(memberAdapter, this);
        }

    }
}