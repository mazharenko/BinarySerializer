using System.Collections.Generic;
using BinarySerializer.Converters;
using BinarySerializer.Converters.Integer;

namespace BinarySerializer
{
    public class SerializationSettings
    {
        public SerializationSettings()
        {
            Converters = new ConvertersCollection(new List<IConverter>
            {
                new BooleanConverter(),
                new IntConverter(),
                new LongConverter(),
                new UIntConverter(),
                new ULongConverter()
            });
            WriterFactory = new ContractSerializationWriterFactory();
        }

        public ConvertersCollection Converters { get; }
        public IContractSerializationWriterFactory WriterFactory { get; set; }
    }
}