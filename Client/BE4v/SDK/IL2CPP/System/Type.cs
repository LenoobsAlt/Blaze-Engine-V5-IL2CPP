using System;
using System.Reflection;
using IL2CPP_Core.Objects;

namespace System
{
    public class IL2Type : IL2MemberInfo
    {
        public IL2Type(IntPtr ptr) : base(ptr) { }

        public IL2AssemblyCore Assembly
        {
            get => Instance_Class.GetProperty(nameof(Assembly)).GetGetMethod().Invoke(this)?.GetValue<IL2AssemblyCore>();
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass(typeof(Type).Name, typeof(Type).Namespace);
    }
}