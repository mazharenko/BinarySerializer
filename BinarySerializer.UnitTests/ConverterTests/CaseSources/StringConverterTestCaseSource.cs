using System;
using System.Collections;
using BinarySerializer.Converters;
using BinarySerializer.UnitTests.ConverterTests.Cases;
using NUnit.Framework;

namespace BinarySerializer.UnitTests.ConverterTests.CaseSources
{
    public class StringConverterTestCaseSource : IEnumerable
    {
        private static readonly Type ConverterType = typeof(StringConverter);
        private const string Key = "String";

        public IEnumerator GetEnumerator()
        {
            yield return new UniversalConverterTestCase<string, byte[]>(string.Empty, new byte[] {0x00}, Key, ConverterType);
            yield return new UniversalConverterTestCase<string, byte[]>("Foo © bar 𝌆 baz ☃ qux",
                new byte[]
                {
                    0x46, 0x6F, 0x6F, 0x20, 0xC2, 0xA9, 0x20, 0x62, 0x61, 0x72, 0x20, 0xF0, 0x9D, 0x8C, 0x86, 0x20,
                    0x62, 0x61, 0x7A, 0x20, 0xE2, 0x98, 0x83, 0x20, 0x71, 0x75, 0x78, 0x00
                }, Key, ConverterType);

            yield return new TestCaseData(GetIHaveADreamExcerpt(), GetIHaveADreamBytes(), ConverterType)
            {
                TestName = "TestStringConverter(I have a dream)"
            };
        }

        private static byte[] GetIHaveADreamBytes()
        {
            return new byte[]
            {
                0x49, 0x20, 0x68, 0x61, 0x76, 0x65, 0x20, 0x61, 0x20, 0x64, 0x72, 0x65, 0x61, 0x6D, 0x20, 0x74, 0x68,
                0x61, 0x74, 0x20, 0x6F, 0x6E, 0x65, 0x20, 0x64, 0x61, 0x79, 0x20, 0x64, 0x6F, 0x77, 0x6E, 0x20, 0x69,
                0x6E, 0x20, 0x41, 0x6C, 0x61, 0x62, 0x61, 0x6D, 0x61, 0x2C, 0x20, 0x77, 0x69, 0x74, 0x68, 0x20, 0x69,
                0x74, 0x73, 0x20, 0x76, 0x69, 0x63, 0x69, 0x6F, 0x75, 0x73, 0x20, 0x72, 0x61, 0x63, 0x69, 0x73, 0x74,
                0x73, 0x2C, 0x20, 0x77, 0x69, 0x74, 0x68, 0x20, 0x69, 0x74, 0x73, 0x20, 0x67, 0x6F, 0x76, 0x65, 0x72,
                0x6E, 0x6F, 0x72, 0x20, 0x68, 0x61, 0x76, 0x69, 0x6E, 0x67, 0x20, 0x68, 0x69, 0x73, 0x20, 0x6C, 0x69,
                0x70, 0x73, 0x20, 0x64, 0x72, 0x69, 0x70, 0x70, 0x69, 0x6E, 0x67, 0x20, 0x77, 0x69, 0x74, 0x68, 0x20,
                0x74, 0x68, 0x65, 0x20, 0x77, 0x6F, 0x72, 0x64, 0x73, 0x20, 0x6F, 0x66, 0x20, 0x69, 0x6E, 0x74, 0x65,
                0x72, 0x70, 0x6F, 0x73, 0x69, 0x74, 0x69, 0x6F, 0x6E, 0x20, 0x61, 0x6E, 0x64, 0x20, 0x6E, 0x75, 0x6C,
                0x6C, 0x69, 0x66, 0x69, 0x63, 0x61, 0x74, 0x69, 0x6F, 0x6E, 0x20, 0xE2, 0x80, 0x93, 0x20, 0x6F, 0x6E,
                0x65, 0x20, 0x64, 0x61, 0x79, 0x20, 0x72, 0x69, 0x67, 0x68, 0x74, 0x20, 0x74, 0x68, 0x65, 0x72, 0x65,
                0x20, 0x69, 0x6E, 0x20, 0x41, 0x6C, 0x61, 0x62, 0x61, 0x6D, 0x61, 0x20, 0x6C, 0x69, 0x74, 0x74, 0x6C,
                0x65, 0x20, 0x62, 0x6C, 0x61, 0x63, 0x6B, 0x20, 0x62, 0x6F, 0x79, 0x73, 0x20, 0x61, 0x6E, 0x64, 0x20,
                0x62, 0x6C, 0x61, 0x63, 0x6B, 0x20, 0x67, 0x69, 0x72, 0x6C, 0x73, 0x20, 0x77, 0x69, 0x6C, 0x6C, 0x20,
                0x62, 0x65, 0x20, 0x61, 0x62, 0x6C, 0x65, 0x20, 0x74, 0x6F, 0x20, 0x6A, 0x6F, 0x69, 0x6E, 0x20, 0x68,
                0x61, 0x6E, 0x64, 0x73, 0x20, 0x77, 0x69, 0x74, 0x68, 0x20, 0x6C, 0x69, 0x74, 0x74, 0x6C, 0x65, 0x20,
                0x77, 0x68, 0x69, 0x74, 0x65, 0x20, 0x62, 0x6F, 0x79, 0x73, 0x20, 0x61, 0x6E, 0x64, 0x20, 0x77, 0x68,
                0x69, 0x74, 0x65, 0x20, 0x67, 0x69, 0x72, 0x6C, 0x73, 0x20, 0x61, 0x73, 0x20, 0x73, 0x69, 0x73, 0x74,
                0x65, 0x72, 0x73, 0x20, 0x61, 0x6E, 0x64, 0x20, 0x62, 0x72, 0x6F, 0x74, 0x68, 0x65, 0x72, 0x73, 0x2E,
                0x0A, 0x0A, 0x49, 0x20, 0x68, 0x61, 0x76, 0x65, 0x20, 0x61, 0x20, 0x64, 0x72, 0x65, 0x61, 0x6D, 0x20,
                0x74, 0x6F, 0x64, 0x61, 0x79, 0x2E, 0x0A, 0x0A, 0x49, 0x20, 0x68, 0x61, 0x76, 0x65, 0x20, 0x61, 0x20,
                0x64, 0x72, 0x65, 0x61, 0x6D, 0x20, 0x74, 0x68, 0x61, 0x74, 0x20, 0x6F, 0x6E, 0x65, 0x20, 0x64, 0x61,
                0x79, 0x20, 0x65, 0x76, 0x65, 0x72, 0x79, 0x20, 0x76, 0x61, 0x6C, 0x6C, 0x65, 0x79, 0x20, 0x73, 0x68,
                0x61, 0x6C, 0x6C, 0x20, 0x62, 0x65, 0x20, 0x65, 0x78, 0x61, 0x6C, 0x74, 0x65, 0x64, 0x2C, 0x20, 0x61,
                0x6E, 0x64, 0x20, 0x65, 0x76, 0x65, 0x72, 0x79, 0x20, 0x68, 0x69, 0x6C, 0x6C, 0x20, 0x61, 0x6E, 0x64,
                0x20, 0x6D, 0x6F, 0x75, 0x6E, 0x74, 0x61, 0x69, 0x6E, 0x20, 0x73, 0x68, 0x61, 0x6C, 0x6C, 0x20, 0x62,
                0x65, 0x20, 0x6D, 0x61, 0x64, 0x65, 0x20, 0x6C, 0x6F, 0x77, 0x2C, 0x20, 0x74, 0x68, 0x65, 0x20, 0x72,
                0x6F, 0x75, 0x67, 0x68, 0x20, 0x70, 0x6C, 0x61, 0x63, 0x65, 0x73, 0x20, 0x77, 0x69, 0x6C, 0x6C, 0x20,
                0x62, 0x65, 0x20, 0x6D, 0x61, 0x64, 0x65, 0x20, 0x70, 0x6C, 0x61, 0x69, 0x6E, 0x2C, 0x20, 0x61, 0x6E,
                0x64, 0x20, 0x74, 0x68, 0x65, 0x20, 0x63, 0x72, 0x6F, 0x6F, 0x6B, 0x65, 0x64, 0x20, 0x70, 0x6C, 0x61,
                0x63, 0x65, 0x73, 0x20, 0x77, 0x69, 0x6C, 0x6C, 0x20, 0x62, 0x65, 0x20, 0x6D, 0x61, 0x64, 0x65, 0x20,
                0x73, 0x74, 0x72, 0x61, 0x69, 0x67, 0x68, 0x74, 0x2C, 0x20, 0x61, 0x6E, 0x64, 0x20, 0x74, 0x68, 0x65,
                0x20, 0x67, 0x6C, 0x6F, 0x72, 0x79, 0x20, 0x6F, 0x66, 0x20, 0x74, 0x68, 0x65, 0x20, 0x4C, 0x6F, 0x72,
                0x64, 0x20, 0x73, 0x68, 0x61, 0x6C, 0x6C, 0x20, 0x62, 0x65, 0x20, 0x72, 0x65, 0x76, 0x65, 0x61, 0x6C,
                0x65, 0x64, 0x20, 0x61, 0x6E, 0x64, 0x20, 0x61, 0x6C, 0x6C, 0x20, 0x66, 0x6C, 0x65, 0x73, 0x68, 0x20,
                0x73, 0x68, 0x61, 0x6C, 0x6C, 0x20, 0x73, 0x65, 0x65, 0x20, 0x69, 0x74, 0x20, 0x74, 0x6F, 0x67, 0x65,
                0x74, 0x68, 0x65, 0x72, 0x2E, 0x0A, 0x0A, 0x54, 0x68, 0x69, 0x73, 0x20, 0x69, 0x73, 0x20, 0x6F, 0x75,
                0x72, 0x20, 0x68, 0x6F, 0x70, 0x65, 0x2E, 0x20, 0x54, 0x68, 0x69, 0x73, 0x20, 0x69, 0x73, 0x20, 0x74,
                0x68, 0x65, 0x20, 0x66, 0x61, 0x69, 0x74, 0x68, 0x20, 0x74, 0x68, 0x61, 0x74, 0x20, 0x49, 0x20, 0x67,
                0x6F, 0x20, 0x62, 0x61, 0x63, 0x6B, 0x20, 0x74, 0x6F, 0x20, 0x74, 0x68, 0x65, 0x20, 0x53, 0x6F, 0x75,
                0x74, 0x68, 0x20, 0x77, 0x69, 0x74, 0x68, 0x2E, 0x20, 0x57, 0x69, 0x74, 0x68, 0x20, 0x74, 0x68, 0x69,
                0x73, 0x20, 0x66, 0x61, 0x69, 0x74, 0x68, 0x20, 0x77, 0x65, 0x20, 0x77, 0x69, 0x6C, 0x6C, 0x20, 0x62,
                0x65, 0x20, 0x61, 0x62, 0x6C, 0x65, 0x20, 0x74, 0x6F, 0x20, 0x68, 0x65, 0x77, 0x20, 0x6F, 0x75, 0x74,
                0x20, 0x6F, 0x66, 0x20, 0x74, 0x68, 0x65, 0x20, 0x6D, 0x6F, 0x75, 0x6E, 0x74, 0x61, 0x69, 0x6E, 0x20,
                0x6F, 0x66, 0x20, 0x64, 0x65, 0x73, 0x70, 0x61, 0x69, 0x72, 0x20, 0x61, 0x20, 0x73, 0x74, 0x6F, 0x6E,
                0x65, 0x20, 0x6F, 0x66, 0x20, 0x68, 0x6F, 0x70, 0x65, 0x2E, 0x20, 0x57, 0x69, 0x74, 0x68, 0x20, 0x74,
                0x68, 0x69, 0x73, 0x20, 0x66, 0x61, 0x69, 0x74, 0x68, 0x20, 0x77, 0x65, 0x20, 0x77, 0x69, 0x6C, 0x6C,
                0x20, 0x62, 0x65, 0x20, 0x61, 0x62, 0x6C, 0x65, 0x20, 0x74, 0x6F, 0x20, 0x74, 0x72, 0x61, 0x6E, 0x73,
                0x66, 0x6F, 0x72, 0x6D, 0x20, 0x74, 0x68, 0x65, 0x20, 0x6A, 0x61, 0x6E, 0x67, 0x6C, 0x69, 0x6E, 0x67,
                0x20, 0x64, 0x69, 0x73, 0x63, 0x6F, 0x72, 0x64, 0x73, 0x20, 0x6F, 0x66, 0x20, 0x6F, 0x75, 0x72, 0x20,
                0x6E, 0x61, 0x74, 0x69, 0x6F, 0x6E, 0x20, 0x69, 0x6E, 0x74, 0x6F, 0x20, 0x61, 0x20, 0x62, 0x65, 0x61,
                0x75, 0x74, 0x69, 0x66, 0x75, 0x6C, 0x20, 0x73, 0x79, 0x6D, 0x70, 0x68, 0x6F, 0x6E, 0x79, 0x20, 0x6F,
                0x66, 0x20, 0x62, 0x72, 0x6F, 0x74, 0x68, 0x65, 0x72, 0x68, 0x6F, 0x6F, 0x64, 0x2E, 0x20, 0x57, 0x69,
                0x74, 0x68, 0x20, 0x74, 0x68, 0x69, 0x73, 0x20, 0x66, 0x61, 0x69, 0x74, 0x68, 0x20, 0x77, 0x65, 0x20,
                0x77, 0x69, 0x6C, 0x6C, 0x20, 0x62, 0x65, 0x20, 0x61, 0x62, 0x6C, 0x65, 0x20, 0x74, 0x6F, 0x20, 0x77,
                0x6F, 0x72, 0x6B, 0x20, 0x74, 0x6F, 0x67, 0x65, 0x74, 0x68, 0x65, 0x72, 0x2C, 0x20, 0x74, 0x6F, 0x20,
                0x70, 0x72, 0x61, 0x79, 0x20, 0x74, 0x6F, 0x67, 0x65, 0x74, 0x68, 0x65, 0x72, 0x2C, 0x20, 0x74, 0x6F,
                0x20, 0x73, 0x74, 0x72, 0x75, 0x67, 0x67, 0x6C, 0x65, 0x20, 0x74, 0x6F, 0x67, 0x65, 0x74, 0x68, 0x65,
                0x72, 0x2C, 0x20, 0x74, 0x6F, 0x20, 0x67, 0x6F, 0x20, 0x74, 0x6F, 0x20, 0x6A, 0x61, 0x69, 0x6C, 0x20,
                0x74, 0x6F, 0x67, 0x65, 0x74, 0x68, 0x65, 0x72, 0x2C, 0x20, 0x74, 0x6F, 0x20, 0x73, 0x74, 0x61, 0x6E,
                0x64, 0x20, 0x75, 0x70, 0x20, 0x66, 0x6F, 0x72, 0x20, 0x66, 0x72, 0x65, 0x65, 0x64, 0x6F, 0x6D, 0x20,
                0x74, 0x6F, 0x67, 0x65, 0x74, 0x68, 0x65, 0x72, 0x2C, 0x20, 0x6B, 0x6E, 0x6F, 0x77, 0x69, 0x6E, 0x67,
                0x20, 0x74, 0x68, 0x61, 0x74, 0x20, 0x77, 0x65, 0x20, 0x77, 0x69, 0x6C, 0x6C, 0x20, 0x62, 0x65, 0x20,
                0x66, 0x72, 0x65, 0x65, 0x20, 0x6F, 0x6E, 0x65, 0x20, 0x64, 0x61, 0x79, 0x2E, 0x0A, 0x0A, 0x54, 0x68,
                0x69, 0x73, 0x20, 0x77, 0x69, 0x6C, 0x6C, 0x20, 0x62, 0x65, 0x20, 0x74, 0x68, 0x65, 0x20, 0x64, 0x61,
                0x79, 0x2C, 0x20, 0x74, 0x68, 0x69, 0x73, 0x20, 0x77, 0x69, 0x6C, 0x6C, 0x20, 0x62, 0x65, 0x20, 0x74,
                0x68, 0x65, 0x20, 0x64, 0x61, 0x79, 0x20, 0x77, 0x68, 0x65, 0x6E, 0x20, 0x61, 0x6C, 0x6C, 0x20, 0x6F,
                0x66, 0x20, 0x47, 0x6F, 0x64, 0xE2, 0x80, 0x99, 0x73, 0x20, 0x63, 0x68, 0x69, 0x6C, 0x64, 0x72, 0x65,
                0x6E, 0x20, 0x77, 0x69, 0x6C, 0x6C, 0x20, 0x62, 0x65, 0x20, 0x61, 0x62, 0x6C, 0x65, 0x20, 0x74, 0x6F,
                0x20, 0x73, 0x69, 0x6E, 0x67, 0x20, 0x77, 0x69, 0x74, 0x68, 0x20, 0x6E, 0x65, 0x77, 0x20, 0x6D, 0x65,
                0x61, 0x6E, 0x69, 0x6E, 0x67, 0x20, 0xE2, 0x80, 0x9C, 0x4D, 0x79, 0x20, 0x63, 0x6F, 0x75, 0x6E, 0x74,
                0x72, 0x79, 0x20, 0xE2, 0x80, 0x99, 0x74, 0x69, 0x73, 0x20, 0x6F, 0x66, 0x20, 0x74, 0x68, 0x65, 0x65,
                0x2C, 0x20, 0x73, 0x77, 0x65, 0x65, 0x74, 0x20, 0x6C, 0x61, 0x6E, 0x64, 0x20, 0x6F, 0x66, 0x20, 0x6C,
                0x69, 0x62, 0x65, 0x72, 0x74, 0x79, 0x2C, 0x20, 0x6F, 0x66, 0x20, 0x74, 0x68, 0x65, 0x65, 0x20, 0x49,
                0x20, 0x73, 0x69, 0x6E, 0x67, 0x2E, 0x20, 0x4C, 0x61, 0x6E, 0x64, 0x20, 0x77, 0x68, 0x65, 0x72, 0x65,
                0x20, 0x6D, 0x79, 0x20, 0x66, 0x61, 0x74, 0x68, 0x65, 0x72, 0xE2, 0x80, 0x99, 0x73, 0x20, 0x64, 0x69,
                0x65, 0x64, 0x2C, 0x20, 0x6C, 0x61, 0x6E, 0x64, 0x20, 0x6F, 0x66, 0x20, 0x74, 0x68, 0x65, 0x20, 0x50,
                0x69, 0x6C, 0x67, 0x72, 0x69, 0x6D, 0xE2, 0x80, 0x99, 0x73, 0x20, 0x70, 0x72, 0x69, 0x64, 0x65, 0x2C,
                0x20, 0x66, 0x72, 0x6F, 0x6D, 0x20, 0x65, 0x76, 0x65, 0x72, 0x79, 0x20, 0x6D, 0x6F, 0x75, 0x6E, 0x74,
                0x61, 0x69, 0x6E, 0x73, 0x69, 0x64, 0x65, 0x2C, 0x20, 0x6C, 0x65, 0x74, 0x20, 0x66, 0x72, 0x65, 0x65,
                0x64, 0x6F, 0x6D, 0x20, 0x72, 0x69, 0x6E, 0x67, 0x21, 0xE2, 0x80, 0x9D, 0x00
            };
        }

        private static string GetIHaveADreamExcerpt()
        {
            return
                "I have a dream that one day down in Alabama, with its vicious racists, with its governor having his " +
                "lips dripping with the words of interposition and nullification – one day right there in Alabama " +
                "little black boys and black girls will be able to join hands with little white boys and white girls " +
                "as sisters and brothers.\n" +
                "\n" +
                "I have a dream today.\n" +
                "\n" +
                "I have a dream that one day every valley shall be exalted, and every hill and mountain shall be made low, " +
                "the rough places will be made plain, and the crooked places will be made straight, and the glory of " +
                "the Lord shall be revealed and all flesh shall see it together.\n" +
                "\n" +
                "This is our hope. This is the faith that I go back to the South with. With this faith we will be " +
                "able to hew out of the mountain of despair a stone of hope. With this faith we will be able to " +
                "transform the jangling discords of our nation into a beautiful symphony of brotherhood. With this " +
                "faith we will be able to work together, to pray together, to struggle together, to go to jail together," +
                " to stand up for freedom together, knowing that we will be free one day.\n" +
                "\n" +
                "This will be the day, this will be the day when all of God’s children will be able to sing " +
                "with new meaning “My country ’tis of thee, sweet land of liberty, of thee I sing. Land where my " +
                "father’s died, land of the Pilgrim’s pride, from every mountainside, let freedom ring!”";
        }

        public static IEnumerable GetWriteCases()
        {
            yield return new UniversalConverterTestCase<string, byte[]>("\0\0\0", new byte[] {0x00}, Key, ConverterType);
            yield return new UniversalConverterTestCase<string, byte[]>("\0\0\0ddd", new byte[] {0x00}, Key, ConverterType);
            yield return new UniversalConverterTestCase<string, byte[]>("x\0n\0s\0g", new byte[] {0x78, 0x00}, Key,
                ConverterType);
        }
    }
}