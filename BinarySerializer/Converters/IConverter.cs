using System;
using System.IO;

namespace BinarySerializer.Converters
{
    public interface IConverter
    {
        Type Type { get; }
        void Write(object source, Stream stream);
        ConverterReadResult Read(Stream stream);
    }
}