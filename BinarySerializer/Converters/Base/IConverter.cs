using System.IO;

namespace BinarySerializer.Converters.Base
{
    public interface IConverter : IConverterBase
    {
        void Write(object source, Stream stream);
        ConverterReadResult Read(Stream stream);
    }
}