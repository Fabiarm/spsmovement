using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Movement.Common
{
    public static class SPManager
    {
        public static SPDocumentLibrary GetDocumentLibrary(string webUrl, string docLibUrl)
        {
            SPDocumentLibrary list = null;
            Helper.RunElevated(webUrl, Guid.Empty, delegate(SPWeb elevatedWeb)
            {
                var rUrl = docLibUrl.TrimStart(elevatedWeb.Url.ToCharArray());
                list = elevatedWeb.Folders[rUrl].DocumentLibrary;
            });
            return list;
        }
    }
}
