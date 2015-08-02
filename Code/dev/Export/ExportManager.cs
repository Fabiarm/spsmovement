using Microsoft.SharePoint;
using Microsoft.SharePoint.Deployment;
using SPS.Movement.Common.Validation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SPS.Movement.Export
{
    public class ExportManager : IExportManager
    {
        public string GetExportFile(SPExportSettings settings)
        {
            xCheck.Require(settings != null);
            return string.Empty;
        }
    }
}
