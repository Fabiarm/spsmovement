﻿using Microsoft.SharePoint;
using Microsoft.SharePoint.Deployment;
using SPS.Movement.Common.Validation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SPS.Movement.Export
{
    public sealed class ExportManager : IExportManager
    {
        SPExportSettings settings;
        string exportPathFile = string.Empty;
        private static volatile ExportManager instance;
        private static object syncRoot = new Object();
        public static string SiteUrl
        {
            get;
            set;
        }
        public string ExportPathFile
        {
            get;
            private set;
        }
        public string ExportBaseFileName
        {
            get;
            private set;
        }
        public static ExportManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ExportManager(SiteUrl);
                    }
                }
                return instance;
            }
        }
        private ExportManager(string siteUrl)
        {
            if (string.IsNullOrEmpty(siteUrl)) throw new Exception("SiteUrl is missing");
            settings = new SPExportSettings();
            settings.SiteUrl = siteUrl;
            settings.AutoGenerateDataFileName = true;
            settings.FileCompression = true;
            settings.ExportPublicSchema = true;
            settings.IncludeSecurity = SPIncludeSecurity.All;
            settings.IncludeVersions = SPIncludeVersions.All;
            settings.ExportMethod = SPExportMethodType.ExportAll;
        }
        public void AddObjects(List<SPExportObject> list)
        {
            xCheck.Require(list != null && list.Count > 0);
            foreach (SPExportObject id in list)
                settings.ExportObjects.Add(id);
        }
        public void Clear()
        {
            settings.ExportObjects.Clear();
        }

        public void RunExport()
        {
            if (settings != null)
                if (settings.ExportObjects != null && settings.ExportObjects.Count > 0)
                {
                    SPExport export = new SPExport(settings);
                    export.Error += Export_Error;
                    export.Run();
                    ExportBaseFileName = export.Settings.BaseFileName;
                    ExportPathFile = export.Settings.FileLocation + "\\" + export.Settings.BaseFileName;
                }
        }
        private void Export_Error(object sender, SPDeploymentErrorEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.ErrorMessage))
                throw new Exception(e.ErrorMessage);
        }
    }
}
