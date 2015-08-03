using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using SPS.Movement.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Movement
{
    public static class SPManager
    {
        public static SPList GetList(string webUrl, string listUrl, SPBaseType type = SPBaseType.DocumentLibrary)
        {
            SPList list = null;
            Helper.RunElevated(webUrl, Guid.Empty, delegate(SPSite elevatedSite, SPWeb elevatedWeb)
            {
                SPListCollection docLibrCollection = elevatedWeb.GetListsOfType(type);
                IEnumerable<SPList> lists = docLibrCollection.OfType<SPList>();
                foreach (var l in lists)
                {
                    string absoluteListUrl = elevatedSite.MakeFullUrl(l.RootFolder.ServerRelativeUrl);
                }
                list = lists.Where(l =>
                    string.Equals(elevatedSite.MakeFullUrl(l.RootFolder.ServerRelativeUrl), listUrl, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            });
            return list;
        }
        public static SPList GetList(string webUrl, Guid listId)
        {
            SPList list = null;
            if (listId == null || listId == Guid.Empty) return list;
            Helper.RunElevated(webUrl, Guid.Empty, delegate (SPSite elevatedSite, SPWeb elevatedWeb)
            {
                try
                {
                    list = elevatedWeb.Lists[listId];
                }
                catch (Exception ex)
                { }
            });
            return list;
        }
    }
}
