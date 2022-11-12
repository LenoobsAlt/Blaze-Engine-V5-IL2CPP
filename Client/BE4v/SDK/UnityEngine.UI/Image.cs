using System;
using IL2CPP_Core.Objects;

namespace UnityEngine.UI
{
    public class Image : Graphic
    {
        public Image(IntPtr ptr) : base(ptr) { }

        public Sprite sprite
        {
            get => Instance_Class.GetProperty(nameof(sprite)).GetGetMethod().Invoke(this)?.GetValue<Sprite>();
            set => Instance_Class.GetProperty(nameof(sprite)).GetSetMethod().Invoke(this, new IntPtr[] { value == null ? IntPtr.Zero : value.Pointer });
        }
        
        public Sprite overrideSprite
        {
            get => Instance_Class.GetProperty(nameof(overrideSprite)).GetGetMethod().Invoke(this)?.GetValue<Sprite>();
            set => Instance_Class.GetProperty(nameof(overrideSprite)).GetSetMethod().Invoke(this, new IntPtr[] { value == null ? IntPtr.Zero : value.Pointer });
        }

        public Material material
        {
            get => Instance_Class.GetProperty(nameof(material)).GetGetMethod().Invoke(this)?.GetValue<Material>();
            set => Instance_Class.GetProperty(nameof(material)).GetSetMethod().Invoke(this, new IntPtr[] { value == null ? IntPtr.Zero : value.Pointer });
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.UI"].GetClass("Image", "UnityEngine.UI");
    }
}
