using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
	public sealed class Texture2D : Texture
	{
		public Texture2D(IntPtr ptr) : base(ptr) { }

		unsafe public Texture2D(int width, int height) : base(IntPtr.Zero)
		{
			Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
			Instance_Class.GetMethod(".ctor", x => x.GetParameters().Length == 2).Invoke(Pointer, new IntPtr[] { new IntPtr(&width), new IntPtr(&height) });
		}

		unsafe public Texture2D(int width, int height, TextureFormat textureFormat, bool mipChain) : base(IntPtr.Zero)
		{
			Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
			Instance_Class.GetMethod(".ctor", x => x.GetParameters().Length == 4).Invoke(Pointer, new IntPtr[] { new IntPtr(&width), new IntPtr(&height), new IntPtr(&textureFormat), new IntPtr(&mipChain) });
		}

		unsafe public void SetPixel(int x, int y, Color color)
		{
			Instance_Class.GetMethod(nameof(SetPixel), m => m.GetParameters().Length == 3).Invoke(this, new IntPtr[] { new IntPtr(&x), new IntPtr(&y), new IntPtr(&color) });
		}

		unsafe public void ReadPixels(Rect source, int destX, int destY)
		{
			Instance_Class.GetMethod(nameof(ReadPixels), x => x.GetParameters().Length == 3).Invoke(this, new IntPtr[] { new IntPtr(&source), new IntPtr(&destX), new IntPtr(&destY) });
		}
		unsafe public void SetPixels(Rect source, int destX, int destY)
		{
			Instance_Class.GetMethod(nameof(SetPixels), x => x.GetParameters().Length == 3).Invoke(this, new IntPtr[] { new IntPtr(&source), new IntPtr(&destX), new IntPtr(&destY) });
		}

		unsafe public void SetPixels(Color[] colors)
		{
			IL2Array<Color> array = null;
			if (colors != null)
            {
				int len = colors.Length;
				array = new IL2Array<Color>(len, Color.Instance_Class);
                for (int i = 0; i < len; i++)
                {
					array[i] = colors[i];
				}
			}
			Instance_Class.GetMethod(nameof(SetPixels), x => x.GetParameters().Length == 1 && x.GetParameters()[0].Name == "colors").Invoke(this, new IntPtr[] { array == null ? IntPtr.Zero : array.Pointer });
		}
		public void Apply()
		{
			Instance_Class.GetMethod(nameof(Apply), x => x.GetParameters().Length == 0).Invoke(this);
		}

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("Texture2D", "UnityEngine");
	}
}
