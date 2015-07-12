using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Movement.Common
{
    public delegate void CodeToRunElevated(SPWeb elevatedWeb);
    public delegate void CodeToRunElevatedAll(SPSite elevatedSite, SPWeb elevatedWeb);
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
        public static void RunElevated(string webUrl, Guid webId, CodeToRunElevatedAll secureCode)
        {
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (SPSite elevatedSite = new SPSite(webUrl))
                {
                    if (webId == null || webId == Guid.Empty)
                        using (SPWeb elevatedWeb = elevatedSite.OpenWeb())
                            secureCode(elevatedSite, elevatedWeb);
                    else
                        using (SPWeb elevatedWeb = elevatedSite.OpenWeb(webId))
                            secureCode(elevatedSite, elevatedWeb);
                }
            });
        }
        public static void CreateDirectory(string path)
        {
            if (Directory.Exists(path) == false)
                Directory.CreateDirectory(path);
        }
    }
}
