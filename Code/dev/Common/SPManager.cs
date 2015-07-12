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
            Helper.RunElevated(webUrl, Guid.Empty, delegate(SPSite elevatedSite, SPWeb elevatedWeb)
            {
                SPListCollection docLibrCollection = elevatedWeb.GetListsOfType(SPBaseType.DocumentLibrary);
                IEnumerable<SPList> lists = docLibrCollection.OfType<SPList>();
                foreach (var l in lists)
                {
                    string absoluteListUrl = elevatedSite.MakeFullUrl(l.RootFolder.ServerRelativeUrl);
                }
                list = (SPDocumentLibrary)lists.Where(l => string.Equals(elevatedSite.MakeFullUrl(l.RootFolder.ServerRelativeUrl), docLibUrl, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            });
            return list;
        }
    }
}
