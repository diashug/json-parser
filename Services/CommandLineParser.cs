using JsonParser.Models;
using System;

namespace JsonParser.Services
{
    public class CommandLineParser
    {
        public CommandLineParser()
        {

        }

        public Option Parse(string[] args)
        {
            var options = new Option();

            if (Array.Exists(args, a => a == "-o"))
            {
                options.Output = args[Array.IndexOf(args, "-o") + 1];
            } else
            {
                throw new Exception("-o: missing the output file path");
            }

            if (Array.Exists(args, a => a == "-u"))
            {
                options.Type = "-u";
                options.Source = args[Array.IndexOf(args, "-u") + 1];
            } else if (Array.Exists(args, a => a == "-f"))
            {
                options.Type = "-f";
                options.Source = args[Array.IndexOf(args, "-f") + 1];
            } else
            {
                throw new Exception("-u or -f: missing the source type");
            }

            if (Array.Exists(args, a => a == "-r"))
            {
                options.RootElement = args[Array.IndexOf(args, "-r") + 1];
            } else
            {
                throw new Exception("-r: missing the root element");
            }

            // optional filter
            if (Array.Exists(args, a => a == "-fields"))
            {
                options.Fields = args[Array.IndexOf(args, "-fields") + 1].Split(',');
            } else {
                options.Fields = null;
            }

            return options;
        }
    }
}