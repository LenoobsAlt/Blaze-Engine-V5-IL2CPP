using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
    public class Rigidbody : Component
    {
        public Rigidbody(IntPtr ptr) : base(ptr) { }

        unsafe public Vector3 velocity
        {
            get => Instance_Class.GetProperty(nameof(velocity)).GetGetMethod().Invoke<Vector3>(this).GetValue();
            set => Instance_Class.GetProperty(nameof(velocity)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
        }

        unsafe public Vector3 angularVelocity
        {
            get => Instance_Class.GetProperty(nameof(angularVelocity)).GetGetMethod().Invoke<Vector3>(this).GetValue();
            set => Instance_Class.GetProperty(nameof(angularVelocity)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
        }

        unsafe public bool isKinematic
        {
            get => Instance_Class.GetProperty(nameof(isKinematic)).GetGetMethod().Invoke<bool>(this).GetValue();
            set => Instance_Class.GetProperty(nameof(isKinematic)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
        }

        unsafe public bool useGravity
        {
            get => Instance_Class.GetProperty(nameof(useGravity)).GetGetMethod().Invoke<bool>(this).GetValue();
            set => Instance_Class.GetProperty(nameof(useGravity)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.PhysicsModule"].GetClass("Rigidbody", "UnityEngine");
    }
}
