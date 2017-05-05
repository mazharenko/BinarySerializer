using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace BinarySerializer.Console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {

                string invokedVerb = null;
                object invokedVerbInstance = null;

                var options = new Options();
                if (!CommandLine.Parser.Default.ParseArguments(args, options,
                    (verb, subOptions) =>
                    {
                        // if parsing succeeds the verb name and correct instance
                        // will be passed to onVerbCommand delegate (string,object)
                        invokedVerb = verb;
                        invokedVerbInstance = subOptions;
                    }))
                {
                    Environment.Exit(CommandLine.Parser.DefaultExitCodeFail);
                }

                if (invokedVerb == "serialize")
                {
                    Serialize((SerializeOptions)invokedVerbInstance);
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                Environment.Exit(1);
            }
        }

        public static void Serialize(SerializeOptions options)
        {
            string objectString;
            Type type;

            if (options.Assembly != null)
            {
                var assembly = Assembly.LoadFrom(Path.GetFullPath(options.Assembly));
                type = assembly.GetType(options.InputType, true);
            }
            else
                type = Type.GetType(options.InputType, true);

            if (options.Input != null)
            {
                objectString = File.ReadAllText(options.Input);
            }
            else
            {
                using (var reader = new StreamReader(System.Console.OpenStandardInput(8192)))
                    objectString = reader.ReadToEnd();
            }

            var @object = JsonConvert.DeserializeObject(objectString, type);

            Stream stream;
            if (options.Output != null)
                stream = File.Create(options.Output);
            else
                stream = System.Console.OpenStandardOutput();

            using (stream)
                ContractSerializer.Serialize(@object, stream);

        }
    }
}