using Microsoft.SharePoint;
using Microsoft.SharePoint.Deployment;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace SPS.Movement.Common
{
    public delegate void CodeToRunElevated(SPWeb elevatedWeb);
    public delegate void CodeToRunElevatedAll(SPSite elevatedSite, SPWeb elevatedWeb);
    public static class Helper
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
        public static SPExportObject GetExportObject(Guid id, SPDeploymentObjectType type, string url)
        {
            var list = new SPExportObject()
            {
                Id = id,
                ExcludeChildren = false,
                Url = url,
                IncludeDescendants = SPIncludeDescendants.All,
                Type = type
            };
            return list;
        }
        public static SPExportObject GetExportObject(SPList l)
        {
            var list = new SPExportObject()
            {
                Id = l.ID,
                ExcludeChildren = false,
                Url = l.RootFolder.Url,
                IncludeDescendants = SPIncludeDescendants.All,
                Type = SPDeploymentObjectType.List
            };
            return list;
        }
        public static void ClosePopup(Control control, string text, bool isRefresh)
        {
            if (String.IsNullOrEmpty(text) == false)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine(string.Format("SP.UI.Notify.addNotification(\"{0}\");", text));
                if (isRefresh == true)
                {
                    stringBuilder.AppendLine("SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, 1);");
                    stringBuilder.AppendLine("window.frameElement.commitPopup();");
                }
                ScriptManager.RegisterClientScriptBlock(control, control.GetType(), Guid.NewGuid().ToString(), stringBuilder.ToString(), true);
            }
        }
    }
}