using System;
using System.Runtime.CompilerServices;
using IL2CPP_Core.Objects;

namespace UnityEngine.XR.WSA
{
	public class WorldAnchor : Component
	{
		public WorldAnchor(IntPtr ptr) : base(ptr) { }

		unsafe public static void Internal_TriggerEventOnTrackingLost(WorldAnchor worldAnchor, bool located)
		{
			Instance_Class.GetMethod(nameof(Internal_TriggerEventOnTrackingLost)).Invoke(new IntPtr[] { worldAnchor == null ? IntPtr.Zero : worldAnchor.Pointer, new IntPtr(&located) });
		}

		private OnTrackingChangedDelegate OnTrackingChanged;

		public delegate void OnTrackingChangedDelegate(WorldAnchor worldAnchor, bool located);

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.VRModule"].GetClass("WorldAnchor", "UnityEngine.XR.WSA");
	}
}
