using System;
using Newtonsoft.Json.Linq;

namespace JsonParser.Interfaces
{
    public interface IExporter
    {
        void Export(string[] filters, JArray data);
    }
}