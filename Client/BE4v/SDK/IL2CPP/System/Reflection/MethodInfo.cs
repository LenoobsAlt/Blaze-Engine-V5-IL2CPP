using System;
using IL2CPP_Core.Objects;

namespace System.Reflection
{
    public class IL2MethodInfo : IL2MethodBase
    {
        public IL2MethodInfo(IntPtr ptr) : base(ptr) { }
		public MemberTypes MemberType
		{
			get => Instance_Class.GetProperty(nameof(MemberType)).GetGetMethod().Invoke<MemberTypes>(this).GetValue();
		}

        public IL2MethodInfo GetBaseDefinition()
        {
            return Instance_Class.GetMethod(nameof(GetBaseDefinition)).Invoke(this)?.GetValue<IL2MethodInfo>();
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass(typeof(MethodInfo).Name, typeof(MethodInfo).Namespace);
    }
}
