using System;
using IL2CPP_Core.Objects;

namespace System.Reflection
{
    public class IL2MonoMethod : IL2RuntimeMethodInfo
    {
        public IL2MonoMethod(IntPtr ptr) : base(ptr) { }

        public IL2MethodInfo GetBaseDefinition()
        {
            return Instance_Class.GetMethod(nameof(GetBaseDefinition)).Invoke(this)?.GetValue<IL2MethodInfo>();
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass("MonoMethod", "System.Reflection");
    }
}
