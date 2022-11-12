using System;
using System.IO;
using System.Net;
using System.Reflection;

public static class Modules
{
    public static void Loading()
    {
        if (!Directory.Exists(mainDir + "/Modules"))
            Directory.CreateDirectory(mainDir + "/Modules");

        if (!IsLoaded.IL2CPPCore)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] bytes = webClient.DownloadData("http://37.230.228.70:5000/IL2CPP-Core.dll");
                    Assembly.Load(bytes);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("[BE4v-Loader]" + mainDir + "/Modules/IL2CPP-Core.dll");
                Console.WriteLine("Ex: " + ex);
            }
        }
    }

    public static class IsLoaded
    {
        public static bool IL2CPPCore
        {
            get
            {
                if (!File.Exists(mainDir + "/Modules/IL2CPP-Core.dll"))
                    return false;

                Assembly.LoadFile(mainDir + "/Modules/IL2CPP-Core.dll");
                return true;
            }
        }
    }

    public static string mainDir = Path.Combine(Environment.CurrentDirectory, "BlazeEngine");
}