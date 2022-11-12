using System;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.ExceptionServices;

namespace InitLoader
{
    public class InitLoader
    {
        [HandleProcessCorruptedStateExceptions]
        public static void Start()
        {
            Main();
        }

        public static void Main()
        {
            Modules.Loading();
            byte[] bytes;
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    bytes = webClient.DownloadData(new Uri("http://37.230.228.70:5000/BE4v-Client.dll"));

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