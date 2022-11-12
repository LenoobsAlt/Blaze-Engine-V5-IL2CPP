using System;
using IL2CPP_Core.Objects;

namespace UnityEngine.UI
{
    public class Selectable : Component
    {
        public Selectable(IntPtr ptr) : base(ptr) { }

        unsafe public bool interactable
        {
            get => Instance_Class.GetProperty(nameof(interactable)).GetGetMethod().Invoke<bool>(this).GetValue();
            set => Instance_Class.GetProperty(nameof(interactable)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.UI"].GetClass("Selectable", "UnityEngine.UI");
    }
}
