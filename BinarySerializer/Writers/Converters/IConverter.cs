using System;
using System.IO;

namespace BinarySerializer.Writers.Converters
{
    public interface IConverter
    {
        Type Type { get; }
        void Write(object source, Stream stream);
    }
}