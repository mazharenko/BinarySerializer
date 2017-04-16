namespace BinarySerializer.UnitTests.ConverterTests
{
    public abstract class BaseConverterTestCase<T> : UniversalConverterTestCase<T>
    {
        protected abstract string Key { get; }

        protected BaseConverterTestCase(T source, byte[] expected) : base(source, expected, string.Empty)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            TestName = $"Test{Key}Converter({source})";
        }
    }
}