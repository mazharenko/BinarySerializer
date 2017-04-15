namespace BinarySerializer.UnitTests.Contracts
{
#pragma warning disable 169
    // ReSharper disable UnusedAutoPropertyAccessor.Local

    public class WithoutAppropriateMembers
    {
        private int PrivateProperty { get; set; } = 10;
        public int ReadonlyProperty { get; } = 10;

        public int WriteOnlyProperty
        {
            set { PrivateProperty = value; }
        }

        private int _privateField = 10;
    }

#pragma warning restore 169
}