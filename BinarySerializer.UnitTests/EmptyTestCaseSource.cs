using System.Collections;
using BinarySerializer.UnitTests.Contracts;
using NUnit.Framework;

namespace BinarySerializer.UnitTests
{
    public class EmptyTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new TestCaseData(new Empty())
            {
                TestName = "TestEmpty"
            };
        }
    }
}