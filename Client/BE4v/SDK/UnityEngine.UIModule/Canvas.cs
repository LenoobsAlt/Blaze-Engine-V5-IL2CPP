using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
    public sealed class Canvas : Behaviour
    {
        public Canvas(IntPtr ptr) : base(ptr) { }

        public Canvas() : base(IntPtr.Zero)
        {
            Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
            Instance_Class.GetMethod(".ctor").Invoke(Pointer);
        }

		unsafe public RenderMode renderMode
		{
            get => Instance_Class.GetProperty(nameof(renderMode)).GetGetMethod().Invoke<RenderMode>(this).GetValue();
            set => Instance_Class.GetProperty(nameof(renderMode)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public bool pixelPerfect
		{
            get => Instance_Class.GetProperty(nameof(pixelPerfect)).GetGetMethod().Invoke<bool>(this).GetValue();
            set => Instance_Class.GetProperty(nameof(pixelPerfect)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
        }

		unsafe public int sortingOrder
		{
            get => Instance_Class.GetProperty(nameof(sortingOrder)).GetGetMethod().Invoke<int>(this).GetValue();
            set => Instance_Class.GetProperty(nameof(sortingOrder)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.UIModule"].GetClass("Canvas", "UnityEngine");
    }
}
