using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

namespace VRC.DevProp
{
    public class SpawnableLight : MonoBehaviour
    {
		public SpawnableLight(IntPtr ptr) : base(ptr) { }

		public struct Preset
		{
			public LightType lightType;

			public float range;

			public float angle;

			public Color color;

			public float intensity;

			public LightShadows shadowType;
		}

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("SetPresetRPC") != null);
    }
}