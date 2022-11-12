using System;
using IL2CPP_Core.Objects;
using UnityEngine;

namespace VRC.SDKBase
{
	public abstract class VRCStation : MonoBehaviour
	{
		public VRCStation(IntPtr ptr) : base(ptr) { }

		unsafe public bool canUseStationFromStation
		{
			get => Instance_Class.GetField(nameof(canUseStationFromStation)).GetValue<bool>(this).GetValue();
			set => Instance_Class.GetField(nameof(canUseStationFromStation)).SetValue(this, new IntPtr(&value));
		}

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["VRCSDKBase"].GetClass("VRCStation", "VRC.SDKBase");
	}
}
