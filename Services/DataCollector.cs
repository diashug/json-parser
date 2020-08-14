using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JsonParser.Services
{
    public class DataCollector
    {
        private readonly string[] fields;

        public DataCollector(string[] fields)
        {
            this.fields = fields;
        }

        public List<string>[] Query(JArray data)
        {
            List<string>[] results = new List<string>[data.Count];
            var i = 0;

            foreach(JToken elem in data)
            {
                if (this.fields != null) {
                    foreach (string field in this.fields) {
                        results[i].Add(elem[field].ToString());
                    }
                } else {
                    results[i] = elem.Values<string>().ToList();
                }

                i ++;
            }

            return results;
        }
    }
}
