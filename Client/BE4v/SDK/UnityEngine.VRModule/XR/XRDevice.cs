using System;
using IL2CPP_Core.Objects;

namespace UnityEngine.XR
{
	public static class XRDevice
	{
		public static bool isPresent
		{
			get => Instance_Class.GetProperty(nameof(isPresent)).GetGetMethod().Invoke<bool>().GetValue();
		}

		[Obsolete]
		public static string model
		{
			get => Instance_Class.GetProperty(nameof(model)).GetGetMethod().Invoke()?.GetValue<IL2String>().ToString();
		}

		public static float refreshRate
		{
			get => Instance_Class.GetProperty(nameof(refreshRate)).GetGetMethod().Invoke<float>().GetValue();
		}

		unsafe public static IntPtr GetNativePtr()
		{
			return Instance_Class.GetMethod(nameof(GetNativePtr)).Invoke<IntPtr>().GetValue();
		}

		[Obsolete]
		public static TrackingSpaceType GetTrackingSpaceType()
		{
			return Instance_Class.GetMethod(nameof(GetTrackingSpaceType)).Invoke<TrackingSpaceType>().GetValue();
		}

		[Obsolete]
		unsafe public static bool SetTrackingSpaceType(TrackingSpaceType trackingSpaceType)
		{
			return Instance_Class.GetMethod(nameof(SetTrackingSpaceType)).Invoke<bool>(new IntPtr[] { new IntPtr(&trackingSpaceType) }).GetValue();
		}

		unsafe public static void DisableAutoXRCameraTracking(Camera camera, bool disabled)
		{
			// Camera not null
			if (camera == null) return;
			Instance_Class.GetMethod(nameof(DisableAutoXRCameraTracking)).Invoke(new IntPtr[] { camera.Pointer, new IntPtr(&disabled) });
		}

		private static void InvokeDeviceLoaded(string loadedDeviceName)
		{
			Instance_Class.GetMethod(nameof(InvokeDeviceLoaded)).Invoke(new IntPtr[] { loadedDeviceName == null ? IntPtr.Zero : new IL2String_utf16(loadedDeviceName).Pointer });
		}

		private static Action<string> deviceLoaded;

		public static IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.VRModule"].GetClass("XRDevice", "UnityEngine.XR");
	}
}
