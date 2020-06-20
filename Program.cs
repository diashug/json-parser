using System;
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
            // args[3] = key to search

            // https://swapi.dev/api/people/

            var result = await client.GetStringAsync(args[1]);
            JObject json = JObject.Parse(result);

            // IEnumerable<JToken> queryResults = json.SelectTokens("$.results[?(@.name)]");

            // foreach(JToken element in queryResults) {
            //     Console.WriteLine(element["height"]);
            // }

            IList<string> results = json[args[2]].Select(s => (string) s.SelectToken(args[3])).ToList();

            foreach(string res in results) {
                Console.WriteLine(res);
            }
        }
    }
}
