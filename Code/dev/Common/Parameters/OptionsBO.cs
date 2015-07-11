using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using System.IO;

namespace SPS.Movement.Common
{
    public class OptionsBO
    {
        [Option('o', "type", Required = true, HelpText = "Enter type export/import")]
        public MType Type { get; set; }

        [Option('w', "web", Required = true, HelpText = "Enter web url, where is a document library")]
        public string WebUrl { get; set; }

        [Option('l', "lib", Required = true, HelpText = "Enter url document library")]
        public string DocLibraryUrl { get; set; }

        [Option('s', "share", Required = true, HelpText = "Enter path to export/import folder")]
        public string ShareFolder { get; set; }

        [Option('t', "time", Required = true, HelpText = "Enter time to get documents")]
        public int Time { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string HelpInfo()
        {
            return "Tool allows to export documents from document library to ZIP file, also import to another document library\n" +
                "Use the followinf parameters:\n" +
                "\t -o (Enter type export/import) \n" +
                "\t -u [url] (Enter web url, where is a document library) \n" +
                "\t -l [url] (Enter url document library) \n" +
                "\t -s [path] (Enter path to export/import folder) \n";
        }
    }
}
