using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
	public sealed class SpriteRenderer : Renderer
	{
        public SpriteRenderer(IntPtr ptr) : base(ptr) { }

        public Sprite sprite
        {
            get => Instance_Class.GetProperty(nameof(sprite)).GetGetMethod().Invoke(this)?.GetValue<Sprite>();
            set => Instance_Class.GetProperty(nameof(sprite)).GetSetMethod().Invoke(this, new IntPtr[] { value == null ? IntPtr.Zero : value.Pointer });
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("SpriteRenderer", "UnityEngine");
	}
}
