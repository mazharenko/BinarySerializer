using System;
using System.IO;
using Newtonsoft.Json;

namespace BinarySerializer.Console
{
    internal partial class Program
    {
        public static void Process(SerializeOptions options, Type type)
        {
            var objectString = new StreamReader(GetInputStream(options.Input)).ReadToEnd();

            var @object = JsonConvert.DeserializeObject(objectString, type);

            using (var stream = GetOutputStream(options.Output))
                ContractSerializer.Serialize(@object, stream);
        }
    }
}