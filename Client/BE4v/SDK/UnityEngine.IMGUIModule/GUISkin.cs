using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
	public sealed class GUISkin : ScriptableObject
	{
		public GUISkin(IntPtr ptr) : base(ptr) { }

		public GUISkin() : base(IntPtr.Zero)
		{
			Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
			Instance_Class.GetMethod(".ctor").Invoke(Pointer);
		}

		public GUIStyle label
		{
			get => Instance_Class.GetProperty(nameof(label)).GetGetMethod().Invoke(this)?.GetValue<GUIStyle>();
			set => Instance_Class.GetProperty(nameof(label)).GetSetMethod().Invoke(this, new IntPtr[] { value == null ? IntPtr.Zero : value.Pointer });
		}

		public GUIStyle box
		{
			get => Instance_Class.GetProperty(nameof(box)).GetGetMethod().Invoke(this)?.GetValue<GUIStyle>();
			set => Instance_Class.GetProperty(nameof(box)).GetSetMethod().Invoke(this, new IntPtr[] { value == null ? IntPtr.Zero : value.Pointer });
		}

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.IMGUIModule"].GetClass("GUISkin", "UnityEngine");
	}
}
