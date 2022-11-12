using System;
using IL2CPP_Core.Objects;

namespace VRCSDK2
{
	public class VRC_MirrorReflection : VRC.SDKBase.VRC_MirrorReflection
	{
		public VRC_MirrorReflection(IntPtr ptr) : base(ptr) { }

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["VRCSDK2"].GetClass("VRC_MirrorReflection", "VRCSDK2");
	}
}
