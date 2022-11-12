using System;
using IL2CPP_Core.Objects;

namespace System.Reflection
{
    public class IL2AssemblyCore : IL2Object
    {
        public IL2AssemblyCore(IntPtr ptr) : base(ptr) { }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass(typeof(Assembly).Name, typeof(Assembly).Namespace);
    }
}
