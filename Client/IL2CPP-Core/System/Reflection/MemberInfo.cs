using System;
using IL2CPP_Core.Objects;

namespace System.Reflection
{
    public class IL2MemberInfo : IL2Object
    {
        public IL2MemberInfo(IntPtr ptr) : base(ptr) { }

        public IL2Type DeclaringType
        {
            get => Instance_Class.GetProperty(nameof(DeclaringType)).GetGetMethod().Invoke(this)?.GetValue<IL2Type>();
        }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass(typeof(MemberInfo).Name, typeof(MemberInfo).Namespace);
    }
}
