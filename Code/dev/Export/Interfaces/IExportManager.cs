using Microsoft.SharePoint.Deployment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Movement.Export
{
    public interface IExportManager
    {
        string GetExportFile(SPExportSettings settings);
    }
}
