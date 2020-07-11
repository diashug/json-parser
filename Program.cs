using JsonParser.Models;
using JsonParser.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JsonParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var commandLineParser = new CommandLineParser();
            var options = commandLineParser.Parse(args);

            var inputReader = new InputReader();
            string result = null;

            if (options.Type == "-u") {
                result = inputReader.FromUrlAsync(options.Source).Result;
            } else if (options.Type == "-f") {
                result = inputReader.FromFileAsync(options.Source).Result;
            } else {
                throw new NotImplementedException("The source type isn't valid. Use -u option to urls or -f for files.");
            }

            JObject json = JObject.Parse(result);
            JArray data = (JArray) json[options.RootElement];

        }
    }
}
