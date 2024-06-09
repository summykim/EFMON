using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM_INK
{
    public static class resultEntity
    {
        public static string sign_type { get; set; }
        public static string sign {  get; set; }
        public static string capture { get; set; }
        public static JArray result { get; set; }

    }
}
