using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
	/// <summary>
	///   <para>Behaviours are Components that can be enabled or disabled.</para>
	/// </summary>
	public class MeshFilter : Component
	{
		public MeshFilter(IntPtr ptr) : base(ptr) { }

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("MeshFilter", "UnityEngine");
	}
}
