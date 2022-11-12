using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
	/// <summary>
	///   <para>Behaviours are Components that can be enabled or disabled.</para>
	/// </summary>
	public class Material : Object
	{
		public Material(IntPtr ptr) : base(ptr) { }

		public Shader shader
		{
			get => Instance_Class.GetProperty(nameof(shader)).GetGetMethod().Invoke(this)?.GetValue<Shader>();
			set => Instance_Class.GetProperty(nameof(shader)).GetSetMethod().Invoke(this, new IntPtr[] { value == null ? IntPtr.Zero : value.Pointer });
		}
		
		unsafe public Color color
		{
			get => Instance_Class.GetProperty(nameof(color)).GetGetMethod().Invoke<Color>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(color)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("Material", "UnityEngine");
	}
}
