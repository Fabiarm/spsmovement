using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Movement.Common
{
    public class OptionsManager
    {
        private static Parser parser;
        static OptionsManager()
        {
            parser = new CommandLine.Parser(
                new ParserSettings()
                {
                    CaseSensitive = false,
                    HelpWriter = Console.Error,
                    IgnoreUnknownArguments = true
                }
                );
        }

        public static OptionsBO ParseArguments(string[] args)
        {
            var options = new OptionsBO();
            var status = parser.ParseArguments(args, options);
            if (status)
                return options;
            return null;
        }
    }
}
