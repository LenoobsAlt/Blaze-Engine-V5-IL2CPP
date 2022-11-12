using System;
using IL2CPP_Core.Objects;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
    public class LayoutGroup : UIBehaviour
    {
		public LayoutGroup(IntPtr ptr) : base(ptr) { }

		unsafe public TextAnchor childAlignment
		{
			get => Instance_Class.GetProperty(nameof(childAlignment)).GetGetMethod().Invoke<TextAnchor>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(childAlignment)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.UI"].GetClass("LayoutGroup", "UnityEngine.UI");
    }
}
