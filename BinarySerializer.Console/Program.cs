using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace BinarySerializer.Console
{
    internal partial class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                object invokedVerbInstance = null;

                var options = new Options();
                if (!CommandLine.Parser.Default.ParseArguments(args, options,
                    (verb, subOptions) =>
                    {
                        // if parsing succeeds the verb name and correct instance
                        // will be passed to onVerbCommand delegate (string,object)
                        invokedVerbInstance = subOptions;
                    }))
                {
                    Environment.Exit(CommandLine.Parser.DefaultExitCodeFail);
                }

                var type = GetType((BaseOptions)invokedVerbInstance);
                Process((dynamic)invokedVerbInstance, type);

            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                Environment.Exit(1);
            }
        }

        public static Stream GetInputStream(string file)
        {
            return file != null ? File.OpenRead(file) : System.Console.OpenStandardInput();
        }

        public static Stream GetOutputStream(string file)
        {
            return file != null ? File.Create(file) : System.Console.OpenStandardOutput();
        }

        public static Type GetType(BaseOptions options)
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