using CommandLine;

namespace BinarySerializer.Console
{
    public class SerializeOptions : BaseOptions, IOptions
    {
        [Option('i', "input", HelpText = "File containing an object to serialize")]
        public string Input { get; set; }

        [Option('o', "output", HelpText = "File-destination for the serialized object. If exists, will be overwritten")]
        public string Output { get; set; }
    }
}