using System;
using IL2CPP_Core.Objects;

namespace VRC.SDKBase
{
	public enum VRCInputMethod
	{
		Keyboard,
		Mouse,
		Controller,
		Gaze,
		Vive = 5,
		Oculus,
		Count
	}

	public class VRCInputMethod_Class : IL2Object
	{
		public VRCInputMethod_Class(IntPtr ptr) : base(ptr) { }

		public static IL2Class Instance_Class = IL2CPP.AssemblyList["VRCSDKBase"].GetClass("VRCInputMethod", "VRC.SDKBase");
	}
}
