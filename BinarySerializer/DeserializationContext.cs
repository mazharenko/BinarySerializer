namespace BinarySerializer
{
    public class DeserializationContext : SerializationContextBase
    {
        // ReSharper disable once SuggestBaseTypeForParameter
        public DeserializationContext(DeserializationSettings settings, System.IO.Stream stream) : base(settings, stream)
        {
        }

        public new DeserializationSettings Settings => (DeserializationSettings) base.Settings;
    }
}