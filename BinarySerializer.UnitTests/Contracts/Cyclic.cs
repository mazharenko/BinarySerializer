namespace BinarySerializer.UnitTests.Contracts
{
    public class Cyclic
    {
        public Cyclic()
        {
            Reference = new CyclicInternal
            {
                Value = 10,
                Reference = this
            };
        }
        
        public CyclicInternal Reference { get; set; }
        
        public class CyclicInternal
        {
            public int Value { get; set; }
            public Cyclic Reference { get; set; }
        }
    }
}