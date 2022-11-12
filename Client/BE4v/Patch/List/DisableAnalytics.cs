using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Runtime;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using IL2CPP_Core.Objects;
using BE4v.SDK;
using BE4v.Patch.Core;

namespace BE4v.Patch.List
{
    public class DisableAnalytics //: IPatch
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string procName);


        public delegate IntPtr _gethostbyname(IntPtr name);
        public delegate IntPtr _getaddrinfo(IntPtr pNodeName, IntPtr pServiceName, IntPtr pHints, IntPtr ppResult);

        public void Start()
        {
            try
            {
                IntPtr hModule = GetModuleHandle("wsock32.dll");
                if (hModule != IntPtr.Zero)
                {
                    IntPtr procAddr = GetProcAddress(hModule, "gethostbyname");
                    if (procAddr != IntPtr.Zero)
                    {
                        __gethostbyname = PatchUtils.FastPatch<_gethostbyname>(procAddr, gethostbyname);
                        "gethostbyname is success patched!".GreenPrefix("Networking");
                    }
                    else
                    {
                        "DisableAnalytics::gethostbyname(string) procAddr is null".RedPrefix("Error");
                        throw new NullReferenceException();
                    }
                }
            }
            catch { }

            try
            {
                IntPtr hModule = GetModuleHandle("ws2_32");
                if (hModule != IntPtr.Zero)
                {
                    IntPtr procAddr = GetProcAddress(hModule, "getaddrinfo");
                    if (procAddr != IntPtr.Zero)
                    {
                        __getaddrinfo = PatchUtils.FastPatch<_getaddrinfo>(procAddr, getaddrinfo);
                        "getaddrinfo is success patched!".GreenPrefix("Networking");
                    }
                    else
                    {
                        throw new NullReferenceException();
                    }
                }
            }
            catch(Exception ex) {  }
        }

        
        private static IntPtr gethostbyname(IntPtr name)
        {
            try
            {
                string origName = Marshal.PtrToStringAnsi(name);
                if (_blackList.Contains(origName))
                {
                    return __gethostbyname(Marshal.StringToHGlobalAnsi("localhost"));
                }
                return __gethostbyname(name);
            }
            catch
            {
                "Bad check analytics!".RedPrefix("Analytics Error");
                return IntPtr.Zero;
            }
        }
        [HandleProcessCorruptedStateExceptions]
        private static IntPtr getaddrinfo(IntPtr pNodeName, IntPtr pServiceName, IntPtr pHints, IntPtr ppResult)
        {
            try
            {
                string origName = Marshal.PtrToStringAnsi(pNodeName);
                if (_blackList.Contains(origName))
                {
                    return __getaddrinfo(Marshal.StringToHGlobalAnsi("localhost"), pServiceName, pHints, ppResult);
                }
                return __getaddrinfo(pNodeName, pServiceName, pHints, ppResult);
            }
            catch
            {
                "Bad check analytics!".RedPrefix("Analytics Error");
                return IntPtr.Zero;
            }
        }

        public static _gethostbyname __gethostbyname;
        public static _getaddrinfo __getaddrinfo;

        public static string[] _blackList =
        {
            "amplitude.com",
            "api.amplitude.com",
            "api2.amplitude.com",
            "api.uca.cloud.unity3d.com",
            "config.uca.cloud.unity3d.com",
            "perf-events.cloud.unity3d.com",
            "public.cloud.unity3d.com",
            "cdp.cloud.unity3d.com",
            "data-optout-service.uca.cloud.unity3d.com",
            "oculus.com",
            "oculuscdn.com",
            "facebook-hardware.com",
            "facebook.net",
            "facebook.com",
            "graph.facebook.com",
            "fbcdn.com",
            "fbsbx.com",
            "fbcdn.net",
            "fb.me",
            "fb.com",
            "crashlytics.com",
            "discordapp.com",
            "dropbox.com",
            "pastebin.com",
            "gluehender-aluhut.de",
            "softlight.at.ua"
        };
    }
}
