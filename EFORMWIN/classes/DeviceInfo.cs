using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM_MON.classes
{

    public class DeviceInfo
    {
         public string uuid { get; set; }
        public string osVersion { get; set; }
        public string appVersion { get; set; }
        public string model { get; set; }
        public string ostype { get; set; }
    }
}
