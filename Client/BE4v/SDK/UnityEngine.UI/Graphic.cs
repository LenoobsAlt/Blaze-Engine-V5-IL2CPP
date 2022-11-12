using System;
using IL2CPP_Core.Objects;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
    public class Graphic : UIBehaviour
    {
        public Graphic(IntPtr ptr) : base(ptr) { }

        unsafe public Color color
        {
            get => Instance_Class.GetProperty(nameof(color)).GetGetMethod().Invoke<Color>(this).GetValue();
            set => Instance_Class.GetProperty(nameof(color)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.UI"].GetClass("Graphic", "UnityEngine.UI");
    }
}
