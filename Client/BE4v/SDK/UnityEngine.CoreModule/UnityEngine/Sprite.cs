using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
	public sealed class Sprite : Object
	{
		public Sprite(IntPtr ptr) : base(ptr) { }

		public Texture2D texture
		{
			get => Instance_Class.GetProperty(nameof(texture)).GetGetMethod().Invoke(this)?.GetValue<Texture2D>();
		}

		public static Sprite Create(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit = 100, uint extrude = 0, SpriteMeshType meshType = SpriteMeshType.Tight, bool generateFallbackPhysicsShape = false)
		{
			Vector4 border = Vector4.zero;
			return Create2(texture, rect, pivot, pixelsPerUnit, extrude, meshType, border, generateFallbackPhysicsShape);
		}
		public Rect rect
		{
			get => Instance_Class.GetProperty(nameof(rect)).GetGetMethod().Invoke<Rect>(this).GetValue();
		}
		public Vector2 pivot
		{
			get => Instance_Class.GetProperty(nameof(pivot)).GetGetMethod().Invoke<Vector2>(this).GetValue();
        }

		public float pixelsPerUnit
        {
			get => Instance_Class.GetProperty(nameof(pixelsPerUnit)).GetGetMethod().Invoke<float>(this).GetValue();
        }

		unsafe private static Sprite Create2(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude, SpriteMeshType meshType, Vector4 border, bool generateFallbackPhysicsShape)
		{
			IntPtr ptrRect = new IntPtr(&rect);
			IntPtr ptrPivot = new IntPtr(&pivot);
			IntPtr ptrBorder = new IntPtr(&border);

			return CreateSprite(texture == null ? IntPtr.Zero : texture.Pointer, ref ptrRect, ref ptrPivot, pixelsPerUnit, extrude, meshType, ref ptrBorder, generateFallbackPhysicsShape);
		}

		private delegate IntPtr _delegateCreateSprite(IntPtr texture, IntPtr rect, IntPtr pivot, float pixelsPerUnit, uint extrude, SpriteMeshType meshType, IntPtr border, bool generateFallbackPhysicsShape);
		private static _delegateCreateSprite _CreateSprite = null;
		private static Sprite CreateSprite(IntPtr texture, ref IntPtr rect, ref IntPtr pivot, float pixelsPerUnit, uint extrude, SpriteMeshType meshType, ref IntPtr border, bool generateFallbackPhysicsShape)
		{
			if (_CreateSprite == null)
			{
				_CreateSprite = IL2CPP.ResolveICall<_delegateCreateSprite>("UnityEngine.Sprite::CreateSprite_Injected");
				if (_CreateSprite == null)
					return null;
			}

			IntPtr result = _CreateSprite(texture, rect, pivot, pixelsPerUnit, extrude, meshType, border, generateFallbackPhysicsShape);
			if (result == IntPtr.Zero)
				return null;

			return new Sprite(result);
		}

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("Sprite", "UnityEngine");
	}
}
