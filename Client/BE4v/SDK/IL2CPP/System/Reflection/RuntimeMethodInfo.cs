using System;
using IL2CPP_Core.Objects;

namespace System.Reflection
{
    public class IL2RuntimeMethodInfo : IL2MethodBase
    {
        public IL2RuntimeMethodInfo(IntPtr ptr) : base(ptr) { }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass("RuntimeMethodInfo", "System.Reflection");
    }
}
