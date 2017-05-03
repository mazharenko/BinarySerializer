using NUnit.Framework;

namespace BinarySerializer.UnitTests.SerializationTests.Cases
{
    public class SerializationTestCase : TestCaseData
    {
        public object Object { get; }
        public byte[] Bytes { get; }

        public SerializationTestCase(object @object, byte[] bytes, string key) : base(@object, bytes)
        {
            Object = @object;
            Bytes = bytes;
            TestName = $"TestSerializaiton{key}({@object})";
        }
    }
}