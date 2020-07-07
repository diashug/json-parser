using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using JsonParser.Models;
using JsonParser.Services;

namespace JsonParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new CommandLineParser(args);
            var inputReader = new InputReader();
            string result = null;

            if (options.Type == "-u") {
                result = inputReader.FromUrl(options.Source);
            } else if (options.Type == "-f") {
                result = inputReader.FromFile(options.Source);
            } else {
                throw new NotImplementedException("The source type isn't valid. Use -u option to urls or -f for files.");
            }

            JObject json = JObject.Parse(result);
            JArray data = (JArray) json[options.RootElement];

            foreach(JToken elem in data)
            {
                foreach (string field in options.Fields) {
                    Console.WriteLine(elem[field]);
                }
            }
        }
    }
}
