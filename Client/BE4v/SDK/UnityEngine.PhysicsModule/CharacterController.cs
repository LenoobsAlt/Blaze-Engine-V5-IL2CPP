using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
    public class CharacterController : Collider
    {
        public CharacterController(IntPtr ptr) : base(ptr) { }

        unsafe public bool isGrounded
        {
            get => Instance_Class.GetProperty(nameof(isGrounded)).GetGetMethod().Invoke<bool>(this).GetValue();
        }
        
        unsafe public Vector3 velocity
        {
            get => Instance_Class.GetProperty(nameof(velocity)).GetGetMethod().Invoke<Vector3>(this).GetValue();
        }

        unsafe public CollisionFlags Move(Vector3 motion)
        {
            return Instance_Class.GetMethod(nameof(Move)).Invoke<CollisionFlags>(this, new IntPtr[] { new IntPtr(&motion) }).GetValue();
        }
        
        unsafe public bool SimpleMove(Vector3 speed)
        {
            return Instance_Class.GetMethod(nameof(SimpleMove)).Invoke<bool>(this, new IntPtr[] { new IntPtr(&speed) }).GetValue();
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.PhysicsModule"].GetClass("CharacterController", "UnityEngine");
    }
}
