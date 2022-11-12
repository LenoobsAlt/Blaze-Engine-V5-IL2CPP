using System;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using IL2CPP_Core.Objects;

namespace UnityEngine.UI
{
    public class GridLayoutGroup : Selectable
    {
        public GridLayoutGroup(IntPtr ptr) : base(ptr) { }

		unsafe public Vector2 spacing
		{
			get => Instance_Class.GetProperty(nameof(spacing)).GetGetMethod().Invoke<Vector2>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(spacing)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.UI"].GetClass("GridLayoutGroup", "UnityEngine.UI");
	}
}
