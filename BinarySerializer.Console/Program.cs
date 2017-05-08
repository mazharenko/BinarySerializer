using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace BinarySerializer.Console
{
    internal delegate void ProcessingDelegate(Type type, Stream input, Stream output);

    internal class Program
    {
        private static readonly IDictionary<string, ProcessingDelegate> ProcessingActions =
            new Dictionary<string, ProcessingDelegate>
            {
                {Verbs.Serialize, Serialize},
                {Verbs.Deserialize, Deserialize}
            };

        public static void Main(string[] args)
        {
            try
            {
                string invokedVerb = null;
                IOptions invokedVerbInstance = null;

                var options = new Options();
                if (!CommandLine.Parser.Default.ParseArguments(args, options,
                    (verb, subOptions) =>
                    {
                        invokedVerb = verb;
                        invokedVerbInstance = (IOptions) subOptions;
                    }))
                {
                    Environment.Exit(CommandLine.Parser.DefaultExitCodeFail);
                }

                var type = GetType(invokedVerbInstance);
                using (var input = GetInputStream(invokedVerbInstance))
                using (var output = GetOutputStream(invokedVerbInstance))
                    ProcessingActions[invokedVerb](type, input, output);
            }
            catch (Exception e)
            {
                System.Console.Error.WriteLine(e);
                Environment.Exit(1);
            }
        }

        public static void Serialize(Type type, Stream input, Stream output)
        {
            using (var reader = new StreamReader(input))
            {
                var objectString = reader.ReadToEnd();

                var @object = JsonConvert.DeserializeObject(objectString, type);

                ContractSerializer.Serialize(@object, output);
            }
        }

        public static void Deserialize(Type type, Stream input, Stream output)
        {
            var deserialized = ContractSerializer.Deserialize(type, input);

            var objectString = JsonConvert.SerializeObject(deserialized);

            using (var writer = new StreamWriter(output))
                writer.Write(objectString);
        }

        public static Stream GetInputStream(IOptions options)
        {
            return options.Input != null ? File.OpenRead(options.Input) : System.Console.OpenStandardInput();
        }

        public static Stream GetOutputStream(IOptions options)
        {
            return options.Output != null ? File.Create(options.Output) : System.Console.OpenStandardOutput();
        }

        public static Type GetType(IOptions options)
        {
            Type type;

            if (options.Assembly != null)
            {
                var assembly = Assembly.LoadFrom(Path.GetFullPath(options.Assembly));
                type = assembly.GetType(options.Type, true);
            }
            else
                type = Type.GetType(options.Type, true);
            return type;
        }
    }
}