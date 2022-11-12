using System;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using IL2CPP_Core.Objects;

namespace UnityEngine.UI
{
    public class Scrollbar : Selectable
    {
        public Scrollbar(IntPtr ptr) : base(ptr) { }

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.UI"].GetClass("Scrollbar", "UnityEngine.UI");
	}
}
