using System;
using IL2CPP_Core.Objects;

namespace System.Reflection
{
    public class IL2ParameterInfo : IL2Object
    {
		public IL2ParameterInfo(IntPtr ptr) : base(ptr) { }

		public IL2Object DefaultValue
		{
			get => Instance_Class.GetProperty(nameof(DefaultValue)).GetGetMethod().Invoke(this);
		}

		public static IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass(typeof(ParameterInfo).Name, typeof(ParameterInfo).Namespace);
    }
}
