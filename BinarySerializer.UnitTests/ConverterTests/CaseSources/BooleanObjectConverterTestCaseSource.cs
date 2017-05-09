using System;
using System.Collections;
using BinarySerializer.UnitTests.ConverterTests.Cases;
using Contracts;

namespace BinarySerializer.UnitTests.ConverterTests.CaseSources
{
    public class BooleanObjectConverterTestCaseSource : IEnumerable
    {
        private static readonly Type ConverterType = typeof(BooleanObjectConverter);


        public static IEnumerable GetSubCases()
        {
            const string key = "BooleanObjectSub";
            yield return new UniversalConverterTestCase<BooleanObject, int>
            (
                new BooleanObject
                {
                    Boolean = false,
                    BooleanField = false
                },
                0, key, ConverterType
            );
            yield return new UniversalConverterTestCase<BooleanObject, int>
            (
                new BooleanObject
                {
                    Boolean = true,
                    BooleanField = false
                },
                2, key, ConverterType
            );
            yield return new UniversalConverterTestCase<BooleanObject, int>
            (
                new BooleanObject
                {
                    Boolean = false,
                    BooleanField = true
                },
                1, key, ConverterType
            );
            yield return new UniversalConverterTestCase<BooleanObject, int>
            (
                new BooleanObject
                {
                    Boolean = true,
                    BooleanField = true
                },
                3, key, ConverterType
            );
        }


        public IEnumerator GetEnumerator()
        {
            const string key = "BooleanObject";

            yield return new UniversalConverterTestCase<BooleanObject, byte[]>
            (
                new BooleanObject
                {
                    Boolean = false,
                    BooleanField = false
                },
                new byte[] {0x80}, key, ConverterType
            );

            yield return new UniversalConverterTestCase<BooleanObject, byte[]>
            (
                new BooleanObject
                {
                    Boolean = true,
                    BooleanField = false
                },
                new byte[] {0x82}, key, ConverterType
            );

            yield return new UniversalConverterTestCase<BooleanObject, byte[]>
            (
                new BooleanObject
                {
                    Boolean = false,
                    BooleanField = true
                },
                new byte[] {0x81}, key, ConverterType
            );

            yield return new UniversalConverterTestCase<BooleanObject, byte[]>
            (
                new BooleanObject
                {
                    Boolean = true,
                    BooleanField = true
                },
                new byte[] {0x83}, key, ConverterType
            );
        }
    }
}