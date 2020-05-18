using System.Collections.Generic;

namespace JsonParser.Interfaces
{
    public interface IExporter
    {
        void Export(Dictionary<string, object> data);
    }
}