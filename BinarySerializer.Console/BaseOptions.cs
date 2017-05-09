using System.Collections.Generic;
using CommandLine;

namespace BinarySerializer.Console
{
    public class BaseOptions
    {
        [Option('t', "type", Required = true, HelpText = "The type of an object.")]
        public string Type { get; set; }

        [Option('a', "assembly", HelpText = "An assembly to lookup the specified type")]
        public string Assembly { get; set; }

        [OptionArray('c', "converter-assemblies", HelpText = "Assemblies to collect converter implementations")]
        public string[] ConverterAssemblies { get; set; }
    }
}