using System;
using JsonParser.Models;

namespace JsonParser.Services
{
    public class CommandLineParser
    {
        private readonly string[] args;

        public CommandLineParser(string[] args)
        {
            this.args = args;
        }

        public Option Parse()
        {
            var options = new Option();

            if (this.args.Any(a => a == "-o"))
            {
                options.Output = this.args[Array.IndexOf(this.args, "-o") + 1];
            } else
            {
                throw new Exception("-o: missing the output file path");
            }

            if (this.args.Any(a => a == "-u"))
            {
                options.Type = "-u";
                options.Source = this.args[Array.IndexOf(this.args, "-u") + 1];
            } else if (this.args.Any(a => a == "-f"))
            {
                options.Type = "-f";
                options.Source = this.args[Array.IndexOf(this.args, "-f") + 1];
            } else
            {
                throw new Exception("-u or -f: missing the source type");
            }

            if (this.args.Any(a => a == "-r"))
            {
                options.rootElement = this.args[Array.IndexOf(this.args, "-r") + 1];
            } else
            {
                throw new Exception("-r: missing the root element");
            }

            // optional filter
            if (this.args.Any(a => a == "-fields"))
            {
                options.Fields = this.args[Array.IndexOf(this.args, "-fields") + 1].Split(',');
            }

            return options;
        }
    }
}