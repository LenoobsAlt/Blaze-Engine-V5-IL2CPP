using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
    public class Collider : Component
    {
		public Collider(IntPtr ptr) : base(ptr) { }

		unsafe public bool enabled
		{
			get => Instance_Class.GetProperty(nameof(enabled)).GetGetMethod().Invoke<bool>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(enabled)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		/*
		public Rigidbody attachedRigidbody
		{
			[Address(RVA = "0x181B15170", Offset = "0x1B13770")]
			get
			{
			}
		}
		*/
		unsafe public bool isTrigger
		{
			get => Instance_Class.GetProperty(nameof(isTrigger)).GetGetMethod().Invoke<bool>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(isTrigger)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public float contactOffset
		{
			get => Instance_Class.GetProperty(nameof(contactOffset)).GetGetMethod().Invoke<float>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(contactOffset)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		/*
		public Vector3 ClosestPoint(Vector3 position)
		{
		}

		public Bounds bounds
		{
			[Address(RVA = "0x181B15240", Offset = "0x1B13840")]
			get
			{
			}
		}

		public PhysicMaterial sharedMaterial
		{
			[Address(RVA = "0x181B15450", Offset = "0x1B13A50")]
			get
			{
			}
			[Address(RVA = "0x181B15670", Offset = "0x1B13C70")]
			set
			{
			}
		}

		public PhysicMaterial material
		{
			[Address(RVA = "0x181B153F0", Offset = "0x1B139F0")]
			get
			{
			}
			[Address(RVA = "0x181B15600", Offset = "0x1B13C00")]
			set
			{
			}
		}
		*/

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.PhysicsModule"].GetClass("Collider", "UnityEngine");
    }
}
