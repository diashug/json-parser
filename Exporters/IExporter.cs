using System.Collections.Generic;

namespace JsonParser.Interfaces
{
    public interface IExporter
    {
        void Export(List<List<string>> data);
    }
}