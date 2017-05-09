using CommandLine;

namespace BinarySerializer.Console
{
    public class DeserializeOptions : BaseOptions, IOptions
    {
        [Option("base64", HelpText = "Declares that the input represents data in a base64-encoded string")]
        public bool Base64 { get; set; }

        [Option('i', "input", HelpText = "File containing a serialized object")]
        public string Input { get; set; }

        [Option('o', "output", HelpText = "File-destination for the deserialized object. If exists, will be overwritten")]
        public string Output { get; set; }
    }
}