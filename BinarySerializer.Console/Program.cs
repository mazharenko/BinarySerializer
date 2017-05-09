using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BinarySerializer.Converters.Base;
using BinarySerializer.Deserialization;
using BinarySerializer.Serialization;
using Newtonsoft.Json;

namespace BinarySerializer.Console
{
    internal delegate void ProcessingDelegate(Type type, Stream input, Stream output, List<IConverterBase> converters);

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
                var converters = CollectConverters(invokedVerbInstance);
                using (var input = GetInputStream((dynamic)invokedVerbInstance))
                using (var output = GetOutputStream(invokedVerbInstance))
                    ProcessingActions[invokedVerb](type, input, output, converters.ToList());
            }
            catch (Exception e)
            {
                System.Console.Error.WriteLine(e);
                Environment.Exit(1);
            }
        }

        private static IEnumerable<IConverterBase> CollectConverters(IOptions invokedVerbInstance)
        {
            if (invokedVerbInstance.ConverterAssemblies == null
                || !invokedVerbInstance.ConverterAssemblies.Any())
                return Enumerable.Empty<IConverterBase>();

            var assemblies = invokedVerbInstance.ConverterAssemblies.Select(Assembly.LoadFrom);
            return assemblies.SelectMany(a => a.GetTypes())
                .Where(t => typeof(ISubConverter).IsAssignableFrom(t)
                            || typeof(IConverter).IsAssignableFrom(t))
                .Where(t => t.GetConstructor(new Type[0]) != null)
                .Select(Activator.CreateInstance)
                .Cast<IConverterBase>();
        }

        public static void Serialize(Type type, Stream input, Stream output, List<IConverterBase> converters)
        {
            using (var reader = new StreamReader(input))
            {
                var objectString = reader.ReadToEnd();

                var @object = JsonConvert.DeserializeObject(objectString, type);

                var settings = new SerializationSettings();
                converters.ForEach(c => settings.Converters.AddConverter((dynamic) c));

                ContractSerializer.Serialize(@object, output, settings);
            }
        }

        public static void Deserialize(Type type, Stream input, Stream output, List<IConverterBase> converters)
        {
            var settings = new DeserializationSettings();
            converters.ForEach(c => settings.Converters.AddConverter((dynamic) c));

            var deserialized = ContractSerializer.Deserialize(type, input, settings);

            var objectString = JsonConvert.SerializeObject(deserialized, Formatting.Indented);

            using (var writer = new StreamWriter(output))
                writer.Write(objectString);
        }

        public static Stream GetInputStream(IOptions options)
        {
            return options.Input != null ? File.OpenRead(options.Input) : System.Console.OpenStandardInput();
        }

        public static Stream GetInputStream(DeserializeOptions options)
        {
            var actual = GetInputStream((IOptions) options);
            if (!options.Base64)
                return actual;
            return new MemoryStream(Convert.FromBase64String(new StreamReader(actual).ReadToEnd()));
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