using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Movement.Common
{
    public delegate void CodeToRunElevated(SPWeb elevatedWeb);
    public class Helper
    {
        public static void RunElevated(Guid siteId, Guid webId, CodeToRunElevated secureCode)
        {
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (SPSite site = new SPSite(siteId))
                {
                    if (webId == null || webId == Guid.Empty)
                        using (SPWeb elevatedWeb = site.OpenWeb())
                            secureCode(elevatedWeb);
                    else
                        using (SPWeb elevatedWeb = site.OpenWeb(webId))
                            secureCode(elevatedWeb);
                }
            });
        }
        public static void RunElevated(string webUrl, Guid webId, CodeToRunElevated secureCode)
        {
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (SPSite site = new SPSite(webUrl))
                {
                    if (webId == null || webId == Guid.Empty)
                        using (SPWeb elevatedWeb = site.OpenWeb())
                            secureCode(elevatedWeb);
                    else
                        using (SPWeb elevatedWeb = site.OpenWeb(webId))
                            secureCode(elevatedWeb);
                }
            });
        }
    }
}
