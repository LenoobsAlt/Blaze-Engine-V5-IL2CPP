using System;
using System.Linq;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
	public class GUILayout
	{
		public static void Label(string text, params GUILayoutOption[] options)
		{
			IL2Array<IntPtr> array = null;
			if (options != null)
			{
				int len = options.Length;
				array = new IL2Array<IntPtr>(len, GUILayoutOption.Instance_Class);
				for (int i = 0; i < len; i++)
				{
					array[i] = options[i] == null ? IntPtr.Zero : options[i].Pointer;
				}
			}
			Instance_Class.GetMethod(nameof(Label), x => x.GetParameters().Length == 2 && x.GetParameters()[0].Name == "text").Invoke(new IntPtr[] { new IL2String_utf16(text).Pointer, array == null ? IntPtr.Zero : array.Pointer });
		}

		public static void Label(string text, GUIStyle style, params GUILayoutOption[] options)
		{
			IL2Array<IntPtr> array = null;
			if (options != null)
			{
				int len = options.Length;
				array = new IL2Array<IntPtr>(len, GUILayoutOption.Instance_Class);
				for (int i = 0; i < len; i++)
				{
					array[i] = options[i] == null ? IntPtr.Zero : options[i].Pointer;
				}
			}
			Instance_Class.GetMethod(nameof(Label), x => x.GetParameters().Length == 3 && x.GetParameters()[0].Name == "text").Invoke(new IntPtr[] { new IL2String_utf16(text).Pointer, style == null ? IntPtr.Zero : style.Pointer, array == null ? IntPtr.Zero : array.Pointer });
		}

		unsafe public static Vector2 BeginScrollView(Vector2 scrollPosition, params GUILayoutOption[] options)
		{
			IL2Array<IntPtr> array = null;
			if (options != null)
			{
				int len = options.Length;
				array = new IL2Array<IntPtr>(len, GUILayoutOption.Instance_Class);
				for (int i = 0; i < len; i++)
				{
					array[i] = options[i] == null ? IntPtr.Zero : options[i].Pointer;
				}
			}
			return Instance_Class.GetMethod(nameof(BeginScrollView), x => x.GetParameters().Length == 2).Invoke<Vector2>(new IntPtr[] { new IntPtr(&scrollPosition), array == null ? IntPtr.Zero : array.Pointer }).GetValue();
		}

		public static void EndScrollView()
		{
			Instance_Class.GetMethod(nameof(EndScrollView), x => x.GetParameters().Length == 0).Invoke();
		}

		public static void BeginHorizontal(params GUILayoutOption[] options)
		{
			IL2Array<IntPtr> array = null;
			if (options != null)
			{
				int len = options.Length;
				array = new IL2Array<IntPtr>(len, GUILayoutOption.Instance_Class);
				for (int i = 0; i < len; i++)
				{
					array[i] = options[i] == null ? IntPtr.Zero : options[i].Pointer;
				}
			}
			Instance_Class.GetMethod(nameof(BeginHorizontal), x => x.GetParameters().Length == 1).Invoke(new IntPtr[] { array == null ? IntPtr.Zero : array.Pointer });
		}

		public static void EndHorizontal()
		{
			Instance_Class.GetMethod(nameof(EndHorizontal)).Invoke();
		}

		unsafe public static void BeginArea(Rect screenRect)
		{
			Instance_Class.GetMethod(nameof(BeginArea), x => x.GetParameters().Length == 1).Invoke(new IntPtr[] { new IntPtr(&screenRect) });
		}

		unsafe public static void BeginArea(Rect screenRect, GUIStyle style)
		{
			Instance_Class.GetMethod(nameof(BeginArea), x => x.GetParameters().Length == 2 && x.GetParameters()[1].Name == "style").Invoke(new IntPtr[] { new IntPtr(&screenRect), style == null ? IntPtr.Zero : style.Pointer });
		}

		unsafe public static void BeginArea(Rect screenRect, Texture image)
		{
			Instance_Class.GetMethod(nameof(BeginArea), x => x.GetParameters().Length == 2 && x.GetParameters()[1].Name == "image").Invoke(new IntPtr[] { new IntPtr(&screenRect), image == null ? IntPtr.Zero : image.Pointer });
		}

		public static void EndArea()
		{
			Instance_Class.GetMethod(nameof(EndArea)).Invoke();
		}

		public static bool Button(string text, params GUILayoutOption[] options)
		{
			IL2Array<IntPtr> array = null;
			if (options != null)
			{
				int len = options.Length;
				array = new IL2Array<IntPtr>(len, GUILayoutOption.Instance_Class);
				for (int i = 0; i < len; i++)
				{
					array[i] = options[i] == null ? IntPtr.Zero : options[i].Pointer;
				}
			}
			return Instance_Class.GetMethod(nameof(Label), x => x.GetParameters().Length == 2 && x.GetParameters()[0].Name == "text").Invoke<bool>(new IntPtr[] { new IL2String_utf16(text).Pointer, array == null ? IntPtr.Zero : array.Pointer }).GetValue();
		}

		public static void Box(Texture image, params GUILayoutOption[] options)
		{
			IL2Array<IntPtr> array = null;
			if (options != null)
            {
				int len = options.Length;
				array = new IL2Array<IntPtr>(len, GUILayoutOption.Instance_Class);
				for (int i = 0;i<len;i++)
                {
					array[i] = options[i] == null ? IntPtr.Zero : options[i].Pointer;
                }
            }
			Instance_Class.GetMethod(nameof(Box), x => x.GetParameters().Length == 2 && x.GetParameters()[0].Name == "image").Invoke(new IntPtr[] { image == null ? IntPtr.Zero : image.Pointer, array == null ? IntPtr.Zero : array.Pointer });
		}

		public static IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.IMGUIModule"].GetClass("GUILayout", "UnityEngine");
	}
}
