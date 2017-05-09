using System.Text;
using BinarySerializer.Converters.Base;

namespace Demo
{
    public class StringAccurateConverter : SubConverter<string, byte[]>
    {
        protected override byte[] WriteInternal(string source)
        {
            return Encoding.UTF8.GetBytes(source);
        }

        protected override string ReadInternal(byte[] source)
        {
            return Encoding.UTF8.GetString(source);
        }
    }
}