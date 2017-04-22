using System;

namespace BinarySerializer.Converters
{
    public interface IConverter
    {
        Type Type { get; }
        void Write(object source, System.IO.Stream stream);
        ConverterReadResult Read(System.IO.Stream stream);
    }
}