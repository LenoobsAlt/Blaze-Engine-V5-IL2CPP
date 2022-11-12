using System;
using VRC.SDKBase;
using IL2CPP_Core.Objects;

namespace VRC.SDK3.Components
{
	public class VRCPickup : VRC_Pickup
	{
		public VRCPickup(IntPtr ptr) : base(ptr) { }

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["VRCSDK3"].GetClass("VRCPickup", "VRC.SDK3.Components");
	}
}
