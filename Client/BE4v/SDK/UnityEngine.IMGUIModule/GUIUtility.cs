using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
	public class GUIUtility : IL2Object
	{
		public GUIUtility(IntPtr ptr) : base(ptr) { }

		public static string systemCopyBuffer
		{
			get => Instance_Class.GetProperty(nameof(systemCopyBuffer)).GetGetMethod().Invoke()?.GetValue<IL2String>().ToString();
			set => Instance_Class.GetProperty(nameof(systemCopyBuffer)).GetSetMethod().Invoke(new IntPtr[] { new IL2String_utf16(value).Pointer });
		}

		public static IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.IMGUIModule"].GetClass("GUIUtility", "UnityEngine");
	}
}
