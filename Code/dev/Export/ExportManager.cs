using Microsoft.SharePoint;
using SPS.Movement.Common;
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

        public void SaveManifest(RootManifestBO manifest)
        {
            xCheck.Require(manifest != null &&
                manifest.DocLibrary != null &&
                manifest.DocLibrary.ID != Guid.Empty);
            Helper.CreateDirectory(Path.Combine(ops.ShareFolder, manifest.DocLibrary.ID.ToString("N")));
            var writer = new XmlSerializer(typeof(RootManifestBO));
            var file = new StreamWriter(Path.Combine(ops.ShareFolder, manifest.DocLibrary.ID.ToString("N"), "RootManifest.xml"), false);
            writer.Serialize(file, manifest);
            file.Close();
        }

        public RootManifestBO CreateManifest()
        {
            RootManifestBO root = new RootManifestBO() { Type = MType.Export };
            root.State = new List<DocumentItem>();
            var docLib = SPManager.GetDocumentLibrary(ops.WebUrl, ops.DocLibraryUrl);
            if (docLib == null)
                throw new Exception("Document libary didn't find on the web");
            root.DocLibrary = new DocumentLibrary() { ID = docLib.ID, Title = docLib.Title };
            var query = new SPQuery() { ViewAttributes = "Scope=\"RecursiveAll\"" };
            var items = docLib.GetItems(query);
            foreach (SPListItem item in items)
            {
                
                root.State.Add(new DocumentItem()
                {
                    ID = item.ID,
                    Title = item.Title,
                    Url = item.Url,
                    Created = Convert.ToDateTime(item[SPBuiltInFieldId.Created_x0020_Date].ToString()),
                    Modified = Convert.ToDateTime(item[SPBuiltInFieldId.Modified].ToString()),
                    IsFolder = item.Folder != null
                });
            }
            return root;
        }
    }
}
