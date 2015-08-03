using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Deployment;
using Microsoft.SharePoint.Utilities;
using SPS.Movement.Export;
using SPS.Movement.Common;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;

namespace SPS.Movement.Layouts.SPS.Movement
{
    public partial class Export : LayoutsPageBase
    {
        Guid listId = Guid.Empty;
        string siteUrl = string.Empty;
        SPDeploymentObjectType type;
        protected override void OnInit(EventArgs e)
        {
            if (Request.QueryString["SiteUrl"] != null)
                siteUrl = Request.QueryString["SiteUrl"].ToString();
            if (Request.QueryString["ListId"] != null)
                listId = Guid.Parse(Request.QueryString["ListId"].ToString());
            if (Request.QueryString["Type"] != null)
            {
                switch (Request.QueryString["Type"].ToLower())
                {
                    case "file":
                        type = SPDeploymentObjectType.File;
                        break;
                    case "folder":
                        type = SPDeploymentObjectType.Folder;
                        break;
                    case "list":
                        type = SPDeploymentObjectType.List;
                        break;
                    case "listitem":
                        type = SPDeploymentObjectType.ListItem;
                        break;
                    case "site":
                        type = SPDeploymentObjectType.Site;
                        break;
                    case "web":
                        type = SPDeploymentObjectType.Web;
                        break;
                    default:
                        type = SPDeploymentObjectType.Invalid;
                        break;
                }
            }
            ExportManager.SiteUrl = siteUrl;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            switch (type)
            {
                case SPDeploymentObjectType.List:
                    if (listId == null || listId == Guid.Empty) throw new Exception("LisId is missing");
                    var l = SPManager.GetList(siteUrl, listId);
                    if (l == null) throw new Exception("List doesn't exist");
                    var list = Helper.GetExportObject(l);
                    ExportManager.Instance.AddObjects(new List<SPExportObject>() { list });
                    break;
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExportFile();
        }

        private void ExportFile()
        {
            try
            {
                ExportManager.Instance.RunExport();
                using (StreamReader sr = new StreamReader(ExportManager.Instance.ExportPathFile, Encoding.UTF8))
                {
                    Helper.ClosePopup(Page, string.Empty, true);
                    Response.ClearHeaders();
                    Response.AddHeader("Content-Type", "application/octet-stream");
                    Response.AddHeader("Content-Disposition", "attachment; filename=\"" + ExportManager.Instance.ExportBaseFileName + "\"");
                    Response.Write(sr);
                    Response.Flush();
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                SPUtility.TransferToErrorPage(ex.ToString());
            }
        }
    }
}
