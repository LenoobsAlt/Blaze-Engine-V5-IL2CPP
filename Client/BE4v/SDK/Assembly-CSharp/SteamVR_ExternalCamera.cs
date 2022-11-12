using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public class SteamVR_ExternalCamera : MonoBehaviour
{
	public SteamVR_ExternalCamera(IntPtr ptr) : base(ptr) { }

	public struct Config
	{
		public float x;

		public float y;

		public float z;

		public float rx;

		public float ry;

		public float rz;

		public float fov;

		public float near;

		public float far;

		public float sceneResolutionScale;

		public float frameSkip;

		public float nearOffset;

		public float farOffset;

		public float hmdOffset;

		public float r;

		public float g;

		public float b;

		public float a;

		public bool disableStandardAssets;
	}

	public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetNestedType("Config") != null);
}