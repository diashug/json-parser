using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsonParser.Services
{
    public class Filter
    {
        private readonly string[] fields;
        public Filter(string[] fields)
        {
            this.fields = fields;
        }

        public List<string>[] Query(JArray data)
        {
            List<string>[] results = new List<string>[data.Count];
            var i = 0;

            foreach(JToken elem in data)
            {
                foreach (string field in this.fields) {
                    results[i].Add(elem[field].ToString());
                }

                i ++;
            }

            return results;
        }
    }
}
