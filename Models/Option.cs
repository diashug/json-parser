using System;

namespace JsonParser.Models
{
    public class Option
    {
        public string Type { get; set; }

        public string Source { get; set; }

        public string RootElement { get; set; }

        public string[] Fields { get; set; }

        public string Output { get; set; }
    }
}