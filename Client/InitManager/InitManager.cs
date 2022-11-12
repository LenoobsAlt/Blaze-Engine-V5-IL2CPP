using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Net.Security;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using VRCLoader.Attributes;
using VRCLoader.Modules;
// using VRCheat.SDK.IL2CPP;

namespace InitManager
{
    [ModuleInfo("BlazeEngine Init Manager", "1.0", "BlazeBest")]
    public class InitManager : VRModule
    {
        public static string PrivateKey { get; private set; }

        public static void Main()
        {
            PrivateKey = null;
            if (File.Exists("lic.ss"))
            {
                PrivateKey = File.ReadAllText("lic.ss");
            }
            byte[] bytes;
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    bytes = webClient.DownloadData(new Uri("http://37.230.228.70:5000/BE4v.dll"));

                    try
                    {
                        var assembly = Assembly.Load(bytes);
                        if (assembly == null)
                            throw new ArgumentNullException();

                        foreach (var type in assembly.GetTypes())
                        {
                            var method = type.GetMethods().FirstOrDefault(m => m.GetCustomAttributes(typeof(HandleProcessCorruptedStateExceptionsAttribute), true).Length > 0 && m.IsStatic && m.GetParameters().Length == 0);
                            if (method != null)
                            {
                                method.Invoke(null, null);
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Init Manager: Bad load!");
                        Console.WriteLine("Ex: " + ex);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Init Manager: Download is failed!");
                    Console.WriteLine("Ex: " + ex);
                }
            }
        }
    }
}
