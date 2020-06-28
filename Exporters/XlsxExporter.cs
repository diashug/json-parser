using JsonParser.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace JsonParser.Exporters
{
    public class XlsxExporter : IExporter
    {
        public XlsxExporter()
        {

        }

        public void Export(string[] filters, JArray data)
        {
            throw new NotImplementedException();
        }
    }
}
