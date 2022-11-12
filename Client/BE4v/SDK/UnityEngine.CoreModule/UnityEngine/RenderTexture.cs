using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
	public class RenderTexture : Texture
	{
		public RenderTexture(IntPtr ptr) : base(ptr) { }

		unsafe public static RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format, RenderTextureReadWrite readWrite)
		{
			return Instance_Class.GetMethod(nameof(GetTemporary), x => x.GetParameters().Length == 5
			&& x.GetParameters()[3].ReturnType.Name == "UnityEngine.RenderTextureFormat" && x.GetParameters()[4].ReturnType.Name == "UnityEngine.RenderTextureReadWrite").Invoke(new IntPtr[] { new IntPtr(&width), new IntPtr(&height), new IntPtr(&depthBuffer), new IntPtr(&format), new IntPtr(&readWrite) })?.GetValue<RenderTexture>();
		}


		public static RenderTexture active
		{
			get => Instance_Class.GetProperty(nameof(active)).GetGetMethod().Invoke()?.GetValue<RenderTexture>();
			set => Instance_Class.GetProperty(nameof(active)).GetSetMethod().Invoke(new IntPtr[] { value == null ? IntPtr.Zero : value.Pointer });
		}

		public static void ReleaseTemporary(RenderTexture temp)
		{
			Instance_Class.GetMethod(nameof(ReleaseTemporary)).Invoke(new IntPtr[] { temp == null ? IntPtr.Zero : temp.Pointer });
		}

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("RenderTexture", "UnityEngine");
	}
}
