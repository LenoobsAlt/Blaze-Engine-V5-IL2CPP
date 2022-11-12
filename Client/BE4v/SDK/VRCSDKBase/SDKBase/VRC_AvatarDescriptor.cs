using System;
using IL2CPP_Core.Objects;
using UnityEngine;

namespace VRC.SDKBase
{
	public abstract class VRC_AvatarDescriptor : MonoBehaviour
	{
		public VRC_AvatarDescriptor(IntPtr ptr) : base(ptr) { }

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["VRCSDKBase"].GetClass("VRC_AvatarDescriptor", "VRC.SDKBase");
	}
}
