using System;
using IL2CPP_Core.Objects;

namespace System.IO
{
    public static class IL2File
    {
        public static void WriteAllBytes(string path, IntPtr bytes)
        {
            Instance_Class.GetMethod(nameof(WriteAllBytes)).Invoke(new IntPtr[] { new IL2String_utf16(path).Pointer, bytes });
        }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass(typeof(File).Name, typeof(File).Namespace);
    }
}
