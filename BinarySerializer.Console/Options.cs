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
}