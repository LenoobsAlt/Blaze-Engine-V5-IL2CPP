using System;
using IL2CPP_Core.Objects;

namespace UnityEngine.UI
{
    public class Button : Selectable
    {
        public Button(IntPtr ptr) : base(ptr) { }

        public ButtonClickedEvent onClick
        {
            get => Instance_Class.GetProperty(nameof(onClick)).GetGetMethod().Invoke(this)?.GetValue<ButtonClickedEvent>();
            set => Instance_Class.GetProperty(nameof(onClick)).GetSetMethod().Invoke(this, new IntPtr[] { value == null ? IntPtr.Zero : value.Pointer });
        }

        public class ButtonClickedEvent : Events.UnityEvent
        {
            public ButtonClickedEvent(IntPtr ptr) : base(ptr) { }

            public ButtonClickedEvent() : base(IntPtr.Zero)
            {
                Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
                Instance_Class.GetMethod(".ctor").Invoke(Pointer);
            }

            public static new IL2Class Instance_Class = Button.Instance_Class.GetNestedType("ButtonClickedEvent");
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.UI"].GetClass("Button", "UnityEngine.UI");
    }
}
