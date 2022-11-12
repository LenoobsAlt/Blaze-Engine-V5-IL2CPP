using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
	/// <summary>
	///   <para>Behaviours are Components that can be enabled or disabled.</para>
	/// </summary>
	public class Behaviour : Component
	{
		public Behaviour(IntPtr ptr) : base(ptr) { }

		unsafe public bool enabled
		{
			get => Instance_Class.GetProperty(nameof(enabled)).GetGetMethod().Invoke<bool>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(enabled)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		public bool isActiveAndEnabled
		{
			get => Instance_Class.GetProperty(nameof(isActiveAndEnabled)).GetGetMethod().Invoke<bool>(this).GetValue();
		}

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("Behaviour", "UnityEngine");
	}
}
