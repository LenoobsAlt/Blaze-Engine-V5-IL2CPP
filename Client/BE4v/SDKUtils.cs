using System;

public static class ClientDebug
{
    public static bool IsEnableDebug() => System.IO.File.Exists("enable_test");
}

public static class SDKUtils
{
    unsafe public static IntPtr ToObjectPtr(this IntPtr[] array)
    {
        var obj = IL2ObjectSystem.Instance_Class;
        
        int length = array.Length;
        IntPtr result = Import.Object.il2cpp_array_new(obj.Pointer, (ulong)length);
        for (int i = 0; i < length; i++)
        {
            *(IntPtr*)((IntPtr)((long*)result + 4) + i * IntPtr.Size) = array[i];
        }
        return result;
    }

    public static void RedPrefix(this string message, string prefix)
    {
        Console.Write("[");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(prefix);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("] " + message);
    }
    
    public static void GreenPrefix(this string message, string prefix)
    {
        Console.Write("[");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(prefix);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("] " + message);
    }

    public static void WriteMessage(this string message, string prefix)
    {
        Console.WriteLine($"[{prefix}] {message}");
    }

    public static void WriteMessage(this string message)
    {
        Console.WriteLine(message);
    }

}