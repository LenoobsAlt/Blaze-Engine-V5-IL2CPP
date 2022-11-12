using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
	public class Texture : Object
	{
		public Texture(IntPtr ptr) : base(ptr) { }

		unsafe public virtual int width
		{
			get => Instance_Class.GetProperty(nameof(width)).GetGetMethod().Invoke<int>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(width)).GetGetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public virtual int height
		{
			get => Instance_Class.GetProperty(nameof(height)).GetGetMethod().Invoke<int>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(height)).GetGetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("Texture", "UnityEngine");
	}
}
