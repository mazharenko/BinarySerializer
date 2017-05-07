using System;
using System.Collections;
using System.Collections.Generic;
using BinarySerializer.Adapters;
using BinarySerializer.Serialization.Providers;
using NUnit.Framework;
using Rhino.Mocks;

namespace BinarySerializer.UnitTests.StreamEntriesProvidersTests
{
    [TestFixture]
    public class EnumerableStreamEntriesProviderTests
    {
        private ListStreamEntriesProvider _provider;

        [SetUp]
        public void SetUp()
        {
            _provider = new ListStreamEntriesProvider();
        }

        [Test]
        [TestCase(typeof(int), false)]
        [TestCase(typeof(IntList), true)]
        [TestCase(typeof(IEnumerable<int>), false)]
        [TestCase(typeof(IList<int>), false)]
        [TestCase(typeof(List<int>), true)]
        [TestCase(typeof(IEnumerable), false)]
        [TestCase(typeof(IEnumerable<>), false)]
        [TestCase(typeof(IList), false)]
        [TestCase(typeof(IList<>), false)]
        [TestCase(typeof(List<>), false)]
        [TestCase(typeof(int[]), true)]
        public void TestIsApplicable(Type memberType, bool expected)
        {
            var member = MockRepository.GenerateStrictMock<ContractMemberAdapter>(null, null);
            member.Stub(m => m.Type).Return(memberType);

            Assert.AreEqual(expected, _provider.GetIsApplicable(member, null));
        }

        public class IntList : List<int>
        {

        }
    }
}