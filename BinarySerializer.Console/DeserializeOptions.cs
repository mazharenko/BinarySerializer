using CommandLine;

namespace BinarySerializer.Console
{
    public class DeserializeOptions : BaseOptions
    {
        [Option('i', "input", HelpText = "File containing a serialized object")]
        public string Input { get; set; }

        [Option('o', "output", HelpText = "File-destination for the deserialized object. If exists, will be overwritten")]
        public string Output { get; set; }
    }
}