using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
    public class BoxCollider : Collider
    {
		public BoxCollider(IntPtr ptr) : base(ptr) { }

		unsafe public Vector3 center
		{
			get => Instance_Class.GetProperty(nameof(center)).GetGetMethod().Invoke<Vector3>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(center)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public Vector3 size
		{
			get => Instance_Class.GetProperty(nameof(size)).GetGetMethod().Invoke<Vector3>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(size)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public Vector3 extents
		{
			get => Instance_Class.GetProperty(nameof(extents)).GetGetMethod().Invoke<Vector3>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(extents)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.PhysicsModule"].GetClass("BoxCollider", "UnityEngine");
    }
}
