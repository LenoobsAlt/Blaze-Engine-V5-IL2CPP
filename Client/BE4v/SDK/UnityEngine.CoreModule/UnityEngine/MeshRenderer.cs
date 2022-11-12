using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
	/// <summary>
	///   <para>Behaviours are Components that can be enabled or disabled.</para>
	/// </summary>
	public class MeshRenderer : Renderer
	{
		public MeshRenderer(IntPtr ptr) : base(ptr) { }



		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("MeshRenderer", "UnityEngine");
	}
}
