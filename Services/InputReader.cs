using System;
using System.IO;
using System.Net.Http;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JsonParser.Services
{
    public class InputReader
    {
        private static readonly HttpClient client = new HttpClient();

        // https://swapi.dev/api/people/

        public async Task<string> FromUrlAsync(string source)
        {
            return await client.GetStringAsync(source);
        }

        public async Task<string> FromFileAsync(string source)
        {
            using (FileStream sourceStream = new FileStream(source,  
                FileMode.Open, FileAccess.Read, FileShare.Read,  
                bufferSize: 4096, useAsync: true))  
            {  
                StringBuilder sb = new StringBuilder();  
        
                byte[] buffer = new byte[0x1000];  
                int numRead;  
                while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0)  
                {  
                    string text = Encoding.Unicode.GetString(buffer, 0, numRead);  
                    sb.Append(text);  
                }  
        
                return sb.ToString();  
            }  
        }
    }
}