using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
	public sealed class GUIStyleState : IL2Object
	{
		public GUIStyleState(IntPtr ptr) : base(ptr) { }

		public GUIStyleState() : base(IntPtr.Zero)
		{
			Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
			Instance_Class.GetMethod(".ctor", x => x.GetParameters().Length == 0).Invoke(Pointer);
		}
		
		unsafe public static GUIStyleState GetGUIStyleState(GUIStyle sourceStyle, IntPtr source)
		{
			return Instance_Class.GetMethod(nameof(GetGUIStyleState)).Invoke(new IntPtr[] { sourceStyle == null ? IntPtr.Zero : sourceStyle.Pointer, new IntPtr(&source) }).GetValue<GUIStyleState>();
		}

		unsafe public Color textColor
		{
			set => Instance_Class.GetProperty(nameof(textColor)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		// System.Void UnityEngine.GUIStyleState::set_background(UnityEngine.Texture2D)
		private delegate IntPtr _set_Background(IntPtr instance, IntPtr texture2D);
		private static _set_Background __set_Background = null;
		unsafe public Texture2D background
		{
			set
			{
				if (__set_Background == null)
                {
					__set_Background = IL2CPP.ResolveICall<_set_Background>("UnityEngine.GUIStyleState::set_background");
					if (__set_Background == null)
                    {
						"not found".RedPrefix("GUIStyleState::set_Background");
						return;
                    }
				}
				__set_Background(Pointer, value == null ? IntPtr.Zero : value.Pointer);
			}
		}

		public static IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.IMGUIModule"].GetClass("GUIStyleState", "UnityEngine");
	}
}
