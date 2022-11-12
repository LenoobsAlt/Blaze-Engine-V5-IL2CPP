using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
	public class Shader : Object
	{
		public Shader(IntPtr ptr) : base(ptr) { }

		public static Shader Find(string name)
		{
			return Instance_Class.GetMethod(nameof(Find)).Invoke(new IntPtr[] { new IL2String_utf16(name).Pointer })?.GetValue<Shader>();
		}

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("Shader", "UnityEngine");
	}
}