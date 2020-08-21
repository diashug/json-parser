using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JsonParser.Services
{
    public class DataCollector
    {
        public DataCollector()
        {
        }

        public List<string>[] Query(JObject data, string rootElement, string[] fields)
        {
            // Examples of JSON Path:
            // $.results[:].*
            // $..[name,height]

            var numberOfResults = data[rootElement].Count();

            for (var i = 0; i < numberOfResults; i ++) {
                var query = "$." + rootElement + "[" + i + "].";

                if (fields != null) {
                    var processedFields = String.Join(",", fields);
                    query += "[" + processedFields + "]";
                } else {
                    query += "*";
                }

                var results = data.SelectTokens(query).Values<string>().ToList();
            }

            

            return null;
        }
    }
}
