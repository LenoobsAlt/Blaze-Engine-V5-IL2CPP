using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
	public class Graphics : IL2Object
	{
		public Graphics(IntPtr ptr) : base(ptr) { }

		public static void Blit(Texture source, RenderTexture dest)
		{
			Instance_Class.GetMethod(nameof(Blit), x => x.GetParameters().Length == 2).Invoke(new IntPtr[] { source == null ? IntPtr.Zero : source.Pointer, dest == null ? IntPtr.Zero : dest.Pointer });
		}

		public static void DrawTexture(Rect screenRect, Texture texture, Material mat)
		{
			int pass = -1;
			DrawTexture(screenRect, texture, mat, pass);
		}

		public static void DrawTexture(Rect screenRect, Texture texture)
		{
			int pass = -1;
			Material mat = null;
			DrawTexture(screenRect, texture, mat, pass);
		}

		public static void DrawTexture(Rect screenRect, Texture texture, Material mat = null, int pass = -1)
		{
			DrawTexture(screenRect, texture, 0, 0, 0, 0, mat, pass);
		}

		public static void DrawTexture(Rect screenRect, Texture texture, int leftBorder, int rightBorder, int topBorder, int bottomBorder, Material mat)
		{
			int pass = -1;
			DrawTexture(screenRect, texture, leftBorder, rightBorder, topBorder, bottomBorder, mat, pass);
		}

		public static void DrawTexture(Rect screenRect, Texture texture, int leftBorder, int rightBorder, int topBorder, int bottomBorder)
		{
			int pass = -1;
			Material mat = null;
			DrawTexture(screenRect, texture, leftBorder, rightBorder, topBorder, bottomBorder, mat, pass);
		}
		public static void DrawTexture(Rect screenRect, Texture texture, int leftBorder, int rightBorder, int topBorder, int bottomBorder, Material mat = null, int pass = -1)
		{
			DrawTexture(screenRect, texture, new Rect(0f, 0f, 1f, 1f), leftBorder, rightBorder, topBorder, bottomBorder, mat, pass);
		}

		public static void DrawTexture(Rect screenRect, Texture texture, Rect sourceRect, int leftBorder, int rightBorder, int topBorder, int bottomBorder, Material mat)
		{
			int pass = -1;
			DrawTexture(screenRect, texture, sourceRect, leftBorder, rightBorder, topBorder, bottomBorder, mat, pass);
		}

		public static void DrawTexture(Rect screenRect, Texture texture, Rect sourceRect, int leftBorder, int rightBorder, int topBorder, int bottomBorder)
		{
			int pass = -1;
			Material mat = null;
			DrawTexture(screenRect, texture, sourceRect, leftBorder, rightBorder, topBorder, bottomBorder, mat, pass);
		}

		public static void DrawTexture(Rect screenRect, Texture texture, Rect sourceRect, int leftBorder, int rightBorder, int topBorder, int bottomBorder, Material mat = null, int pass = -1)
		{
			Color32 c = new Color32(128, 128, 128, 128);
			DrawTextureImpl(screenRect, texture, sourceRect, leftBorder, rightBorder, topBorder, bottomBorder, c, mat, pass);
		}

		unsafe private static void DrawTextureImpl(Rect screenRect, Texture texture, Rect sourceRect, int leftBorder, int rightBorder, int topBorder, int bottomBorder, Color color, Material mat, int pass)
		{
			Instance_Class.GetMethod(nameof(DrawTextureImpl)).Invoke(new IntPtr[] { new IntPtr(&screenRect), texture == null ? IntPtr.Zero : texture.Pointer, new IntPtr(&sourceRect), new IntPtr(&leftBorder), new IntPtr(&rightBorder), new IntPtr(&topBorder), new IntPtr(&bottomBorder), new IntPtr(&color), mat == null ? IntPtr.Zero : mat.Pointer, new IntPtr(&pass) });
		}

		public static IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("Graphics", "UnityEngine");
	}
}
