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

        public void Export(List<List<string>> data)
        {
            var writer = new StreamWriter("output.csv");
            var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csv.WriteRecords(data);
        }
    }
}