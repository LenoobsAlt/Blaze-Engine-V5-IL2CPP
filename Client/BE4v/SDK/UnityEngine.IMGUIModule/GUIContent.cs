using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
	public sealed class GUIContent : IL2Object
	{
		public GUIContent(IntPtr ptr) : base(ptr) { }

		public GUIContent() : base(IntPtr.Zero)
		{
			Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
			Instance_Class.GetMethod(".ctor", x => x.GetParameters().Length == 0).Invoke(Pointer);
		}
		public GUIContent(string text) : base(IntPtr.Zero) => new GUIContent(new IL2String_utf16(text));
		public GUIContent(IL2String text) : base(IntPtr.Zero)
		{
			Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
			Instance_Class.GetMethod(".ctor", x => x.GetParameters().Length == 1 && x.GetParameters()[0].Name == "text").Invoke(Pointer, new IntPtr[] { text.Pointer });
		}

		public static IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.IMGUIModule"].GetClass("GUIContent", "UnityEngine");
	}
}
