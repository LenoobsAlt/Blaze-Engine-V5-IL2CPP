using System;
using IL2CPP_Core.Objects;
using UnityEngine;

namespace VRC.SDKBase
{
	public abstract class VRC_MirrorReflection : MonoBehaviour
	{
		public VRC_MirrorReflection(IntPtr ptr) : base(ptr) { }
		public bool m_DisablePixelLights;

		public bool TurnOffMirrorOcclusion;

		unsafe public LayerMask m_ReflectLayers
		{
			get => Instance_Class.GetField(nameof(m_ReflectLayers)).GetValue<LayerMask>(this).GetValue();
			set => Instance_Class.GetField(nameof(m_ReflectLayers)).SetValue(this, new IntPtr(&value));
		}

		private enum Dimension
		{
			Auto,
			X256 = 256,
			X512 = 512,
			X1024 = 1024
		}

		private enum AntialiasingSamples
		{
			X1 = 1,
			X2,
			X4 = 4,
			X8 = 8
		}

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["VRCSDKBase"].GetClass("VRC_MirrorReflection", "VRC.SDKBase");
	}
}
