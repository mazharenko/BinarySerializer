using BinarySerializer.Writers.Converters;
using BinarySerializer.Writers.Converters.Integer;

namespace BinarySerializer
{
    public class ContractSerializationSettings
    {
        public ContractSerializationSettings()
        {
            Converters = new ConvertersCollection
            {
                new BooleanConverter()
            };
        }

        public ConvertersCollection Converters { get; }
    }
}