using System;
using IL2CPP_Core.Objects;

namespace UnityEngine.UI
{
    // Text -> MaskableGraphic -> Graphic
    public class Text : Graphic
    {
        public Text(IntPtr ptr) : base(ptr) { }

        public Text() : base(IntPtr.Zero)
        {
            Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
            Instance_Class.GetMethod(".ctor").Invoke(Pointer);
        }

        public string text
        {
            get => Instance_Class.GetProperty(nameof(text)).GetGetMethod().Invoke(this)?.GetValue<IL2String>().ToString();
            set => Instance_Class.GetProperty(nameof(text)).GetSetMethod().Invoke(this, new IntPtr[] { new IL2String_utf16(value).Pointer });
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.UI"].GetClass("Text", "UnityEngine.UI");
    }
}
