using System;
using IL2CPP_Core.Objects;
using UnityEngine;

namespace VRC.SDKBase
{
	public class VRCPlayerApi : IL2Object
	{
		public VRCPlayerApi(IntPtr ptr) : base(ptr) { }

		unsafe public void SetVelocity(Vector3 motion)
		{
			Instance_Class.GetMethod(nameof(SetVelocity)).Invoke(this, new IntPtr[] { new IntPtr(&motion) });
		}
		
		unsafe public void SetJumpImpulse(float impulse = 3f)
		{
			Instance_Class.GetMethod(nameof(SetJumpImpulse)).Invoke(this, new IntPtr[] { new IntPtr(&impulse) });
		}

		public static IL2Class Instance_Class = IL2CPP.AssemblyList["VRCSDKBase"].GetClass("VRCPlayerApi", "VRC.SDKBase");
	}
}
