using System;
using System.IO;
using System.Net.Http;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace JsonParser
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            // args[0] = source type (url or file)
            // args[1] = url or filename
            // args[2] = root to search
            // args[3] = filters (separated by comma)
            // https://swapi.dev/api/people/

            var app = new CommandLineApplication<Program>(throwOnUnexpectedArg: false);

            var type = args[0];
            var source = args[1];
            var searchRoot = args[2];
            var filters = args[3].Split(",");
            var output = args[4];

            string result = null;

            if (type == "-u") {
                result = await client.GetStringAsync(source);
            } else if (type == "-f") {
                result = File.ReadAllText(source);
            } else {
                throw new NotImplementedException("The source type isn't valid. Use -u option to urls or -f for files.");
            }

            args.Select(a => a == "-o")
            if (a)
            
            if (args.Contains("-o")) {

            }
            
            JObject json = JObject.Parse(result);
            JArray data = (JArray) json[args[2]];

            


        }
    }
}
