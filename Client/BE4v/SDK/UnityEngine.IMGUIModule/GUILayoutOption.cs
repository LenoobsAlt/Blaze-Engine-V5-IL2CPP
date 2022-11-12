using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
	public sealed class GUILayoutOption : IL2Object
	{
		public GUILayoutOption(IntPtr ptr) : base(ptr) { }

		unsafe internal GUILayoutOption(Type type, IntPtr value) : base(IntPtr.Zero)
		{
			Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
			Instance_Class.GetMethod(".ctor", x => x.GetParameters().Length == 2).Invoke(Pointer, new IntPtr[] { new IntPtr(&type), value });
		}


		unsafe internal Type type
		{
			get => Instance_Class.GetField(nameof(type)).GetValue<Type>(this).GetValue();
			set => Instance_Class.GetField(nameof(type)).SetValue(this, new IntPtr(&value));
		}
		

		unsafe internal IntPtr value
		{
			get
			{
				IL2Object result = Instance_Class.GetField(nameof(value)).GetValue(this);
				return (result == null) ? IntPtr.Zero : result.Pointer;
			}
			set => Instance_Class.GetField(nameof(value)).SetValue(this, new IntPtr(&value));
		}

		internal enum Type
		{
			fixedWidth,
			fixedHeight,
			minWidth,
			maxWidth,
			minHeight,
			maxHeight,
			stretchWidth,
			stretchHeight,
			alignStart,
			alignMiddle,
			alignEnd,
			alignJustify,
			equalSize,
			spacing
		}

		public static IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.IMGUIModule"].GetClass("GUILayoutOption", "UnityEngine");
	}
}
