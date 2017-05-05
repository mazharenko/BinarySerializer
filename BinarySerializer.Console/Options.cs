using CommandLine;
using CommandLine.Text;

namespace BinarySerializer.Console
{
    public class Options
    {
        [HelpVerbOption]
        public string GetUsage(string verb)
        {
            return HelpText.AutoBuild(this, verb);
        }

        [VerbOption("serialize", HelpText = "Perform a serialization operation")]
        public SerializeOptions SerializeVerb { get; set; }

        [VerbOption("deserialize", HelpText = "Perform a deserialization operation")]
        public DeserializeOptions DeserializeVerb { get; set; }
    }

    public class SerializeOptions
    {
        [Option('t', "type", Required = true, HelpText = "The type of an object.")]
        public string InputType { get; set; }

        [Option('a', "assembly", HelpText = "The assembly to lookup the specified type")]
        public string Assembly { get; set; }

        [Option('i', "input", HelpText = "File containing an object to serialize")]
        public string Input { get; set; }

        [Option('o', "output", HelpText = "File-destination for the serialized object. If exists, will be overwritten")]
        public string Output { get; set; }
    }

    public class DeserializeOptions
    {

    }

}