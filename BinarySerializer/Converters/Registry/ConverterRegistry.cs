using System;
using BinarySerializer.Converters.Base;
using BinarySerializer.Converters.Integer;

namespace BinarySerializer.Converters.Registry
{
    public class ConverterRegistry : IConverterRegistry
    {
        private readonly ConvertersCollection<IConverter> _converters =
            new ConvertersCollection<IConverter>
            {
                new BooleanConverter(),
                new IntConverter(),
                new LongConverter(),
                new UIntConverter(),
                new ULongConverter(),
                new StringConverter(),
                new ByteConverter(),
                new SByteConverter()
            };

        private readonly ConvertersCollection<ISubConverter> _subConverters =
            new ConvertersCollection<ISubConverter>
            {
                new TimeSpanConverter()
            };

        public void AddConverter(IConverter converter) => _converters.Add(converter);

        public void AddConverter(ISubConverter converter) => _subConverters.Add(converter);

        public IConverter GetConverter(Type type)
        {
            var subConverter = _subConverters.Find(type);
            if (subConverter == null)
                return _converters.Find(type);
            var c = GetConverter(subConverter.SubType);
            if (c != null)
                return new SubbedConverter(subConverter, c);
            return _converters.Find(type);
        }
    }
}