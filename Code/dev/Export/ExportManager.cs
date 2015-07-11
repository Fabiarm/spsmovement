using Microsoft.SharePoint;
using SPS.Movement.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SPS.Movement.Export
{
    public class ExportManager : IExportManager, IManifest
    {
        OptionsBO ops;
        public ExportManager(OptionsBO options)
        {
            ops = options;
        }

        public void GetDocuments()
        {
            //throw new NotImplementedException();
        }

        public void ExportToZip()
        {
            //throw new NotImplementedException();
        }

        public void ExportDocuments()
        {
            //throw new NotImplementedException();
        }

        public ManifestBO CreateManifest()
        {
           // var docLib = SPManager.GetDocumentLibrary(ops.WebUrl, ops.DocLibraryUrl);
            //var tt = docLib.GetItems(new string[] { "Title" });
            return null;
            //throw new NotImplementedException();
        }
        public void SaveManifest(ManifestBO manifest)
        {
            //throw new NotImplementedException();
        }
        public void SaveRootManifest(RootManifestBO manifest)
        {
            var writer = new XmlSerializer(typeof(RootManifestBO));
            var file = new StreamWriter(ops.ShareFolder + @"\RootManifest.xml", false);
            writer.Serialize(file, manifest);
            file.Close();
        }
        public RootManifestBO CreateRootManifest()
        {
            RootManifestBO root = new RootManifestBO() { Type = MType.Export };
            root.State = new List<DocumentItem>();
            var docLib = SPManager.GetDocumentLibrary(ops.WebUrl, ops.DocLibraryUrl);
            var items = docLib.GetItems(new string[] { "Title" });
            foreach (SPListItem item in items)
            {
                root.State.Add(new DocumentItem()
                {
                    ID = item.ID,
                    Title = item.Title,
                    Url = item.Url,
                    Created = Convert.ToDateTime(item[SPBuiltInFieldId.Created_x0020_Date].ToString()),
                    Modified = Convert.ToDateTime(item[SPBuiltInFieldId.Modified].ToString())
                });
            }
            return root;
        }
    }
}
