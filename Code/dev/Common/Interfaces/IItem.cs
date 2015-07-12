using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Movement.Common
{
    public interface IItem
    {
        int ID { get; set; }
        string Title { get; set; }
        string Url { get; set; }
        DateTime Modified { get; set; }
        DateTime Created { get; set; }
        bool IsFolder { get; set; }
    }
}
