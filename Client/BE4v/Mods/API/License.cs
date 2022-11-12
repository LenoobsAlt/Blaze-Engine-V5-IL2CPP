using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE4v.Mods.API
{
    public static class License
    {
        private static string _license = null;
        public static string GetLicense
        {
            get
            {
                if (_license == null)
                {
                    if (File.Exists("lic.ss"))
                    {
                        _license = File.ReadAllText("lic.ss");
                    }
                    else
                        _license = string.Empty;
                }
                return _license;
            }
        }

        public static void Connect()
        {
            string result = Core.Request("api/license");
            IsLicense = result.Contains("Success");
        }


        public static List<string> AvatarId = new List<string>();
        public static bool? IsLicense = null;
    }
}
