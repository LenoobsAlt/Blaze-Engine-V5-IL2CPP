using System;
using IL2CPP_Core.Objects;

namespace UnityEngine.XR
{
	public static class XRStats
	{
		unsafe public static bool TryGetGPUTimeLastFrame(out float gpuTimeLastFrame)
		{
			fixed (float* gpuTimeLastFramePtr = &gpuTimeLastFrame)
			{
				return Instance_Class.GetMethod(nameof(TryGetGPUTimeLastFrame)).Invoke<bool>(new IntPtr[] { new IntPtr(gpuTimeLastFramePtr) }).GetValue();
			}
		}

		public static IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.VRModule"].GetClass("XRStats", "UnityEngine.XR");
	}
}
