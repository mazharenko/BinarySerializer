namespace BinarySerializer.UnitTests.ConverterTests.Cases
{
    public abstract class BaseConverterTestCase<T> : UniversalConverterTestCase<T>
    {
        protected abstract string Key { get; }

        protected BaseConverterTestCase(T source, byte[] bytes) : base(source, bytes, string.Empty)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            TestName = $"Test{Key}Converter({source})";
        }
    }
}