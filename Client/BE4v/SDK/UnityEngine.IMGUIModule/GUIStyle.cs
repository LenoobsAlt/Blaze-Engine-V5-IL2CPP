using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
	public sealed class GUIStyle : IL2Object
	{
		public GUIStyle(IntPtr ptr) : base(ptr) { }

		public GUIStyle() : base(IntPtr.Zero)
		{
			Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
			Instance_Class.GetMethod(".ctor", x => x.GetParameters().Length == 0).Invoke(Pointer);
		}

		unsafe public IntPtr GetStyleStatePtr(int idx)
		{
			return Instance_Class.GetMethod(nameof(GetStyleStatePtr)).Invoke<IntPtr>(this, new IntPtr[] { new IntPtr(&idx) }).GetValue();
		}

		public GUIStyle box
		{
			get => Instance_Class.GetProperty(nameof(box)).GetGetMethod().Invoke(this)?.GetValue<GUIStyle>();
			set => Instance_Class.GetProperty(nameof(box)).GetSetMethod().Invoke(this, new IntPtr[] { value == null ? IntPtr.Zero : value.Pointer });
		}

		public GUIStyleState normal
		{
			get
			{
				if (m_Normal == null)
				{
					m_Normal = GUIStyleState.GetGUIStyleState(this, GetStyleStatePtr(0));
				}
				return m_Normal;
			}
			set
			{
				// AssignStyleState(0, value.m_Ptr);
			}
		}

		public GUIStyleState hover
		{
			get
			{
				if (m_Hover == null)
				{
					m_Hover = GUIStyleState.GetGUIStyleState(this, GetStyleStatePtr(1));
				}
				return m_Hover;
			}
			set
			{
				// AssignStyleState(1, value.m_Ptr);
			}
		}

		unsafe public int fontSize
		{
			set => Instance_Class.GetProperty(nameof(fontSize)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public FontStyle fontStyle
		{
			set => Instance_Class.GetProperty(nameof(fontStyle)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public TextAnchor alignment
		{
			set { } // Instance_Class.GetProperty(nameof(alignment)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
		}

		public GUIStyleState m_Normal
		{
			get => Instance_Class.GetField(nameof(m_Normal)).GetValue(this)?.GetValue<GUIStyleState>();
			set => Instance_Class.GetField(nameof(m_Normal)).SetValue(this, value == null ? IntPtr.Zero : value.Pointer);
		}

		public GUIStyleState m_Hover
		{
			get => Instance_Class.GetField(nameof(m_Hover)).GetValue(this)?.GetValue<GUIStyleState>();
			set => Instance_Class.GetField(nameof(m_Hover)).SetValue(this, value == null ? IntPtr.Zero : value.Pointer);
		}
		
		public static IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.IMGUIModule"].GetClass("GUIStyle", "UnityEngine");
	}
}
