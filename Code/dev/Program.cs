using SPS.Movement.Common;
using SPS.Movement.Export;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Movement
{
    class Program
    {
        public static void Main(string[] args)
        {
            OptionsBO ops = OptionsManager.ParseArguments(args);
            if (ops != null)
            {
                switch (ops.Type)
                {
                    case MType.Export:
                        Export(ops);
                        break;
                    case MType.Import:
                        break;
                }
            }
        }

        public static void Export(OptionsBO ops)
        {
            ExportManager manager = new Export.ExportManager(ops);
            var m = manager.CreateManifest();
            manager.SaveManifest(m);
        }
    }
}
