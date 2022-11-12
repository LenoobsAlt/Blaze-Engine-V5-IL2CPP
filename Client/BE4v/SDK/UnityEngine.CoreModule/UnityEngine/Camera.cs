using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
    public sealed class Camera : MonoBehaviour
    {
        public Camera(IntPtr ptr) : base(ptr) { }

        public static Camera main
        {
            get => Instance_Class.GetProperty(nameof(main)).GetGetMethod().Invoke()?.GetValue<Camera>();
        }

        public static Camera current
        {
            get => Instance_Class.GetProperty(nameof(current)).GetGetMethod().Invoke()?.GetValue<Camera>();
        }

        unsafe public Ray ScreenPointToRay(Vector3 pos)
        {
            return Instance_Class.GetMethod("ScreenPointToRay", x => x.GetParameters().Length == 1).Invoke<Ray>(this, new IntPtr[] { new IntPtr(&pos) }).GetValue();
        }

        unsafe public Vector3 WorldToScreenPoint(Vector3 position, Camera.MonoOrStereoscopicEye eye)
        {
            return Instance_Class.GetMethod(nameof(WorldToScreenPoint), x => x.GetParameters().Length == 2).Invoke<Vector3>(this, new IntPtr[] { new IntPtr(&position), new IntPtr(&eye) }).GetValue();
        }

        unsafe public Vector3 WorldToScreenPoint(Vector3 position)
        {
            return Instance_Class.GetMethod(nameof(WorldToScreenPoint), x => x.GetParameters().Length == 1).Invoke<Vector3>(this, new IntPtr[] { new IntPtr(&position) }).GetValue();
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("Camera", "UnityEngine");

        public enum StereoscopicEye
        {
            Left,
            Right
        }

        public enum MonoOrStereoscopicEye
        {
            Left,
            Right,
            Mono
        }
    }
}
