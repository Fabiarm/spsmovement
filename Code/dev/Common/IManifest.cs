using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Movement.Common
{
    public interface IManifest
    {
        ManifestBO CreateManifest();
        void SaveManifest(ManifestBO manifest);
    }
}