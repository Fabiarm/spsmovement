using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Movement.Common
{
    [Serializable]
    public class ManifestBO
    {
        public MType Type { get; set; }
        public List<DocumentItem> Added { get; set; }
        public List<DocumentItem> Updated { get; set; }
        public List<DocumentItem> Removed { get; set; }
    }
    [Serializable]
    public class RootManifestBO
    {
        public MType Type { get; set; }
        public List<DocumentItem> State { get; set; }
    }
    [Serializable]
    public class DocumentItem : IItem
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
    }
}