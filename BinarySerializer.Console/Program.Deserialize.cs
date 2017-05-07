using System;
using System.IO;
using Newtonsoft.Json;

namespace BinarySerializer.Console
{
    internal partial class Program
    {
        public static void Process(DeserializeOptions options, Type type)
        {
            object deserialized;
            using (var stream = GetInputStream(options.Input))
                deserialized = ContractSerializer.Deserialize(type, stream);

            var objectString = JsonConvert.SerializeObject(deserialized);

            using (var writer = new StreamWriter(GetOutputStream(options.Output)))
            {
                writer.Write(objectString);
            }
        }
    }
}