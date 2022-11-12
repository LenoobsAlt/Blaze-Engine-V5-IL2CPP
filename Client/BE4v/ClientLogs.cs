using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ClientLogs
{
    public static void ClearLogs()
    {
        logs.Clear();
    }

    public static void Add(string message)
    {
        logs.Add(CurrentTime() + " " + message);
    }

    private static string CurrentTime()
    {
        return "[" + DateTime.Now.ToString("HH:mm:ss tt") + "]";
    }

    public static List<string> logs = new List<string>();
}