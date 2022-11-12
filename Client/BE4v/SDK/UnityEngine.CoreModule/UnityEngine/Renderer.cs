using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
	/// <summary>
	///   <para>Behaviours are Components that can be enabled or disabled.</para>
	/// </summary>
	public class Renderer : MonoBehaviour
	{
		public Renderer(IntPtr ptr) : base(ptr) { }

		public Material material
		{
			get => Instance_Class.GetProperty(nameof(material)).GetGetMethod().Invoke(this)?.GetValue<Material>();
			set => Instance_Class.GetProperty(nameof(material)).GetSetMethod().Invoke(this, new IntPtr[] { value == null ? IntPtr.Zero : value.Pointer });
		}

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("Renderer", "UnityEngine");
	}
}
