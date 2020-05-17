namespace JsonParser.Interfaces
{
    public interface IExporter
    {
         int Type;
         string OutputPath;
         
         void export();
    }
}