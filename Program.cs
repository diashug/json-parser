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

            string type = null;
            string source = null;
            string elementRoot = null;
            string[] fields = null;
            string output = null;

            string result = null;

            if (args.Any(a => a == "-o"))
            {
                output = args[Array.IndexOf(args, "-o") + 1];
            } else
            {
                throw new Exception("-o: missing the output file path");
            }

            if (args.Any(a => a == "-u"))
            {
                type = "-u";
                source = args[Array.IndexOf(args, "-u") + 1];
            } else if (args.Any(a => a == "-f"))
            {
                type = "-f";
                source = args[Array.IndexOf(args, "-f") + 1];
            } else
            {
                throw new Exception("-u or -f: missing the source type");
            }

            if (args.Any(a => a == "-r"))
            {
                elementRoot = args[Array.IndexOf(args, "-r") + 1];
            } else
            {
                throw new Exception("-r: missing the root element");
            }

            // optional filter
            if (args.Any(a => a == "-fields"))
            {
                fields = args[Array.IndexOf(args, "-fields") + 1].Split(',');
            }

            if (type == "-u") {
                result = await client.GetStringAsync(source);
            } else if (type == "-f") {
                result = File.ReadAllText(source);
            } else {
                throw new NotImplementedException("The source type isn't valid. Use -u option to urls or -f for files.");
            }
            
            JObject json = JObject.Parse(result);
            JArray data = (JArray) json[elementRoot];

            foreach(JToken elem in data)
            {
                foreach (string field in fields) {
                    Console.WriteLine(elem[field]);
                }
            }
        }
    }
}
