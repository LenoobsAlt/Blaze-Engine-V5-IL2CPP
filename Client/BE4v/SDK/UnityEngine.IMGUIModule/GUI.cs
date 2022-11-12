using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
	public class GUI
	{
		unsafe public static Color contentColor
		{
			get => Instance_Class.GetProperty(nameof(contentColor)).GetGetMethod().Invoke<Color>().GetValue();
			set => Instance_Class.GetProperty(nameof(contentColor)).GetSetMethod().Invoke(new IntPtr[] { new IntPtr(&value) });
		}

		public static void Box(Rect position, string text, GUIStyle style = null) => Box(position, new IL2String_utf8(text), style);
		unsafe public static void Box(Rect position, IL2String text, GUIStyle style = null)
		{
			if (style == null)
				style = skin.box;
			Instance_Class.GetMethod(nameof(Box), m => m.GetParameters().Length == 3 && m.GetParameters()[1].Name == "text").Invoke(new IntPtr[] { new IntPtr(&position), text.Pointer, style.Pointer });
		}

		/*

		public static void Box(Rect position, string text, GUIStyle style)
		{
		}

		public static void Box(Rect position, GUIContent content, GUIStyle style)
		{
		}
		*/

		public static void Label(Rect position, string text, GUIStyle style = null) => Label(position, new IL2String_utf16(text), style);
		unsafe public static void Label(Rect position, IL2String text, GUIStyle style = null)
		{
			if (style == null)
				style = skin.label;

			Instance_Class.GetMethod(nameof(Label), m => m.GetParameters().Length == 3 && m.GetParameters()[1].Name == "text").Invoke(new IntPtr[] { new IntPtr(&position), text.Pointer, style.Pointer });
		}
		/*
		public static void Label(Rect position, GUIContent content, GUIStyle style)
		{
		}
		*/
		unsafe public static bool Button(Rect position, string text) => Button(position, new IL2String_utf16(text));
		unsafe public static bool Button(Rect position, IL2String text)
		{
			return Instance_Class.GetMethod(nameof(Button), m => m.GetParameters().Length == 2).Invoke<bool>(new IntPtr[] { new IntPtr(&position), text.Pointer }).GetValue();
		}

		unsafe public static bool Button(Rect position, string text, GUIStyle style) => Button(position, new GUIContent(text), style);
		unsafe public static bool Button(Rect position, GUIContent content, GUIStyle style)
		{
			return Instance_Class.GetMethod(nameof(Button), m => m.GetParameters().Length == 3).Invoke<bool>(new IntPtr[] { new IntPtr(&position), content == null ? IntPtr.Zero : content.Pointer, style == null ? IntPtr.Zero : style.Pointer }).GetValue();
		}

		/*
		// Token: 0x06000050 RID: 80 RVA: 0x0000218C File Offset: 0x0000038C
		[Address(RVA = "0x18182E560", Offset = "0x182CB60")]
		public static bool Button(Rect position, GUIContent content, GUIStyle style)
		{
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00002190 File Offset: 0x00000390
		[Address(RVA = "0x18182E480", Offset = "0x182CA80")]
		internal static bool Button(Rect position, int id, GUIContent content, GUIStyle style)
		{
		}
		*/
		public static Color backgroundColor
		{
			get
			{
				Color result;
				INTERNAL_get_backgroundColor(out result);
				return result;
			}
			set
			{
				INTERNAL_set_backgroundColor(ref value);
			}
		}

		private delegate void _INTERNAL_get_backgroundColor(out Color value);
		private static _INTERNAL_get_backgroundColor _delegateGet_backgroundColor = null;
		private static void INTERNAL_get_backgroundColor(out Color value)
		{
			if (_delegateGet_backgroundColor == null)
			{
				_delegateGet_backgroundColor = IL2CPP.ResolveICall<_INTERNAL_get_backgroundColor>("UnityEngine.GUI::get_backgroundColor_Injected");
				if (_delegateGet_backgroundColor == null)
                {
					value = new Color();
					return;
				}
			}

			_delegateGet_backgroundColor(out value);
		}

		private delegate void _INTERNAL_set_backgroundColor(ref Color value);
		private static _INTERNAL_set_backgroundColor _delegateSet_backgroundColor = null;
		private static void INTERNAL_set_backgroundColor(ref Color value)
		{
			if (_delegateSet_backgroundColor == null)
			{
				_delegateSet_backgroundColor = IL2CPP.ResolveICall<_INTERNAL_set_backgroundColor>("UnityEngine.GUI::set_backgroundColor_Injected");
				if (_delegateSet_backgroundColor == null)
					return;
			}

			_delegateSet_backgroundColor(ref value);
		}

		public static GUISkin skin
		{
			get => Instance_Class.GetProperty(nameof(skin)).GetGetMethod().Invoke()?.GetValue<GUISkin>();
			set => Instance_Class.GetProperty(nameof(skin)).GetGetMethod().Invoke(new IntPtr[] { (value == null) ? IntPtr.Zero : value.Pointer });
		}

		public static IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.IMGUIModule"].GetClass("GUI", "UnityEngine");
	}
}
