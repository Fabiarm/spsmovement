using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Movement.Common
{
    public interface IExportManager
    {
        void GetDocuments();
        void ExportToZip();
        void ExportDocuments();
    }
}
