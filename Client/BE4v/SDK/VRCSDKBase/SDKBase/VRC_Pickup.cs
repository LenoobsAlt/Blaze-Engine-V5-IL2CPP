using System;
using IL2CPP_Core.Objects;
using UnityEngine;

namespace VRC.SDKBase
{
	public abstract class VRC_Pickup : MonoBehaviour
	{
		public VRC_Pickup(IntPtr ptr) : base(ptr) { }

		unsafe public bool pickupable
		{
			get => Instance_Class.GetField(nameof(pickupable)).GetValue<bool>(this).GetValue();
			set => Instance_Class.GetField(nameof(pickupable)).SetValue(this, new IntPtr(&value));
		}

		unsafe public float proximity
		{
			get => Instance_Class.GetField(nameof(proximity)).GetValue<float>(this).GetValue();
			set => Instance_Class.GetField(nameof(proximity)).SetValue(this, new IntPtr(&value));
		}
		
		unsafe public bool allowManipulationWhenEquipped
		{
			get => Instance_Class.GetField(nameof(allowManipulationWhenEquipped)).GetValue<bool>(this).GetValue();
			set => Instance_Class.GetField(nameof(allowManipulationWhenEquipped)).SetValue(this, new IntPtr(&value));
		}

		unsafe public PickupOrientation orientation
		{
			get => Instance_Class.GetField(nameof(orientation)).GetValue<PickupOrientation>(this).GetValue();
			set => Instance_Class.GetField(nameof(orientation)).SetValue(this, new IntPtr(&value));
		}

		public enum PickupOrientation
		{
			Any,
			Grip,
			Gun
		}


		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["VRCSDKBase"].GetClass("VRC_Pickup", "VRC.SDKBase");
	}
}
