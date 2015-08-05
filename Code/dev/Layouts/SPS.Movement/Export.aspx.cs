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
using SPS.Movement.Export.Interfaces;

namespace SPS.Movement.Layouts.SPS.Movement
{
    public partial class Export : LayoutsPageBase, IQuerySettings
    {
        private QSettings settings;
        protected override void OnInit(EventArgs e)
        {
            SetSettings(HttpContext.Current);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void SetSettings()
        {
            ExportManager.Instance.Clear();
            switch (settings.Type)
            {
                case SPDeploymentObjectType.List:
                    if (settings.ListId == null || settings.ListId == Guid.Empty) throw new Exception("LisId is missing");
                    var l = SPManager.GetList(settings.SiteUrl, settings.ListId);
                    if (l == null) throw new Exception("List doesn't exist");
                    var list = Helper.GetExportObject(l);
                    ExportManager.Instance.AddObjects(new List<SPExportObject>() { list });
                    break;
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            SetSettings();
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
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                SPUtility.TransferToErrorPage(ex.ToString());
            }
        }

        public void SetSettings(HttpContext context)
        {
            settings = Helper.GetSettings(context.Request);
            if (!string.IsNullOrEmpty(settings.SiteUrl))
                ExportManager.SiteUrl = settings.SiteUrl;
        }
    }
}
