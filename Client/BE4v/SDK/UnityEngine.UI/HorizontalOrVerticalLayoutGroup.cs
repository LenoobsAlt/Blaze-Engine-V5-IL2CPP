using System;
using IL2CPP_Core.Objects;

namespace UnityEngine.UI
{
    public abstract class HorizontalOrVerticalLayoutGroup : LayoutGroup
    {
		public HorizontalOrVerticalLayoutGroup(IntPtr ptr) : base(ptr) { }

		unsafe public bool childControlHeight
		{
			get => Instance_Class.GetProperty(nameof(childControlHeight)).GetGetMethod().Invoke<bool>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(childControlHeight)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.UI"].GetClass("HorizontalOrVerticalLayoutGroup", "UnityEngine.UI");
    }
}
