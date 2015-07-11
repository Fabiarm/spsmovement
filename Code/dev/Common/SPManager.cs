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
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(webUrl))
                using (SPWeb web = site.OpenWeb())
                {
                    var rUrl = docLibUrl.TrimStart(web.Url.ToCharArray());
                    list = web.Folders[rUrl].DocumentLibrary;
                }
            });
            return list;
        }
    }
}
