using System;
using IL2CPP_Core.Objects;
using UnityEngine;

namespace VRC.SDKBase
{
	public static class Networking
	{
        public static int GetServerTimeInMilliseconds()
        {
            return Instance_Class.GetMethod(nameof(GetServerTimeInMilliseconds)).Invoke<int>().GetValue();
        }


        public static VRCPlayerApi GetOwner(GameObject obj)
		{
			return Instance_Class.GetMethod(nameof(GetOwner)).Invoke(new IntPtr[] { obj == null ? IntPtr.Zero : obj.Pointer })?.GetValue<VRCPlayerApi>();
		}

		public static void SetOwner(VRCPlayerApi player, GameObject obj)
		{
			Instance_Class.GetMethod(nameof(SetOwner)).Invoke(new IntPtr[] { player == null ? IntPtr.Zero : player.Pointer, obj == null ? IntPtr.Zero : obj.Pointer });
		}

		public static VRCPlayerApi LocalPlayer
		{
			get => Instance_Class.GetProperty(nameof(LocalPlayer)).GetGetMethod().Invoke()?.GetValue<VRCPlayerApi>();
		}

		public static IL2Class Instance_Class = IL2CPP.AssemblyList["VRCSDKBase"].GetClass("Networking", "VRC.SDKBase");
	}
}
