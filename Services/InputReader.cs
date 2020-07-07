using System;
using System.IO;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JsonParser.Services
{
    public class InputReader
    {
        private static readonly HttpClient client = new HttpClient();

        // https://swapi.dev/api/people/

        public async Task<string> FromUrl(string source)
        {
            return await client.GetStringAsync(source);
        }

        public async Task<string> FromFile(string source)
        {
            return await File.ReadAllText(source);
        }
    }
}