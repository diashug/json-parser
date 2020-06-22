using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using JsonParser.Interfaces;
using CsvHelper;

namespace JsonParser.Exporters
{
    public class CsvExporter : IExporter
    {
        public CsvExporter()
        {
            
        }

        public void Export(string[] filters, JArray data)
        {
            var records = new List<object>();

            foreach (JObject res in data) {
                // filter by fields
                foreach (string filter in filters) {
                    
                }

                Console.WriteLine(res["name"] + "," + res["birth_year"]);
            }

            var writer = new StreamWriter("output.csv");
            var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csv.WriteRecords(records);
        }
    }
}