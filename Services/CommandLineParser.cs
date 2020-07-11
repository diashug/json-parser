using System;
using JsonParser.Models;

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

            if (args.Any(a => a == "-o"))
            {
                options.Output = args[Array.IndexOf(args, "-o") + 1];
            } else
            {
                throw new Exception("-o: missing the output file path");
            }

            if (args.Any(a => a == "-u"))
            {
                options.Type = "-u";
                options.Source = args[Array.IndexOf(args, "-u") + 1];
            } else if (args.Any(a => a == "-f"))
            {
                options.Type = "-f";
                options.Source = args[Array.IndexOf(args, "-f") + 1];
            } else
            {
                throw new Exception("-u or -f: missing the source type");
            }

            if (args.Any(a => a == "-r"))
            {
                options.rootElement = args[Array.IndexOf(args, "-r") + 1];
            } else
            {
                throw new Exception("-r: missing the root element");
            }

            // optional filter
            if (args.Any(a => a == "-fields"))
            {
                options.Fields = args[Array.IndexOf(args, "-fields") + 1].Split(',');
            }

            return options;
        }
    }
}