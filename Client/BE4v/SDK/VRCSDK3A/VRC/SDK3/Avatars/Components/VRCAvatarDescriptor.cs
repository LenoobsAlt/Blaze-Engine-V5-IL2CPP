using System;
using IL2CPP_Core.Objects;
using UnityEngine;
using VRC.SDKBase;

namespace VRC.SDK3.Avatars.Components
{
	public class VRCAvatarDescriptor : VRC_AvatarDescriptor
	{
		public VRCAvatarDescriptor(IntPtr ptr) : base(ptr) { }

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["VRCSDK3A"].GetClass("VRCAvatarDescriptor", "VRC.SDK3.Avatars.Components");
	}
}
