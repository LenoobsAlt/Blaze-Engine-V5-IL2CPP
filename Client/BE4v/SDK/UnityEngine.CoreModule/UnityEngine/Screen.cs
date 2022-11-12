using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
	public sealed class Screen
	{
		public static int width
		{
			get => Instance_Class.GetProperty(nameof(width)).GetGetMethod().Invoke<int>().GetValue();
		}

		public static int height
		{
			get => Instance_Class.GetProperty(nameof(height)).GetGetMethod().Invoke<int>().GetValue();
		}

		public static IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("Screen", "UnityEngine");
	}
}
