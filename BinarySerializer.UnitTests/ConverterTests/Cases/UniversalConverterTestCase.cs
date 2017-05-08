using System;
using NUnit.Framework;

namespace BinarySerializer.UnitTests.ConverterTests.Cases
{
    public class UniversalConverterTestCase<T, TSub> : TestCaseData
    {
        public T Object { get; }
        public TSub ObjectSub { get; }

        public UniversalConverterTestCase(T @object, TSub sub, string key, Type converterType)
            : base(@object, sub, converterType)
        {
            Object = @object;
            ObjectSub = sub;
            TestName = $"Test{key}Converter({@object})";
        }
    }
}