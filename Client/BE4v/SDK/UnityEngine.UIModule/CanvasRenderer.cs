using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
    public sealed class CanvasRenderer : Component
    {
        public CanvasRenderer(IntPtr ptr) : base(ptr) { }

        public void SetTexture(Texture texture)
        {
            Instance_Class.GetMethod(nameof(SetTexture)).Invoke(this, new IntPtr[] { texture == null ? IntPtr.Zero : texture.Pointer });
        }

        public void SetAlphaTexture(Texture texture)
        {
            Instance_Class.GetMethod(nameof(SetAlphaTexture)).Invoke(this, new IntPtr[] { texture == null ? IntPtr.Zero : texture.Pointer });
        }


        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.UIModule"].GetClass("CanvasRenderer", "UnityEngine");
    }
}
