using System;
using System.IO;

namespace BinarySerializer.Converters.Base
{
    public class SubbedConverter : IConverter
    {
        private readonly ISubConverter _subConverter;
        private readonly IConverter _converter;

        public SubbedConverter(ISubConverter subConverter, IConverter converter)
        {
            _subConverter = subConverter;
            _converter = converter;
        }

        public Type Type => _subConverter.Type;

        public void Write(object source, Stream stream)
        {
            _converter.Write(_subConverter.Write(source), stream);
        }

        public ConverterReadResult Read(Stream stream)
        {
            var readResult = _converter.Read(stream);
            if (readResult.Value != null)
                readResult.Value = _subConverter.Read(readResult.Value);
            return readResult;
        }
    }
}