using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VRCLoader.Utils
{
    public static class Logs
    {
        public static void Log(string message, object arg0, object arg1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("VRCLoader");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message + "\n", arg0, arg1);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void Log(string message, object arg0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("VRCLoader");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message + "\n", arg0);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("VRCLoader");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message + "\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
