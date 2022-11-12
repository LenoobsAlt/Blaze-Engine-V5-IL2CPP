using System;
using System.Runtime.InteropServices;

namespace UnityEngine
{
	/// <summary>
	///   <para>Representation of RGBA colors in 32 bit format.</para>
	/// </summary>
	[StructLayout(LayoutKind.Explicit)]
	public struct Color32
	{
		/// <summary>
		///   <para>Constructs a new Color32 with given r, g, b, a components.</para>
		/// </summary>
		/// <param name="r"></param>
		/// <param name="g"></param>
		/// <param name="b"></param>
		/// <param name="a"></param>
		// Token: 0x06001350 RID: 4944 RVA: 0x0001D572 File Offset: 0x0001B772
		public Color32(byte r, byte g, byte b, byte a)
		{
			rgba = 0;
			this.r = r;
			this.g = g;
			this.b = b;
			this.a = a;
		}

		public static implicit operator Color32(Color c)
		{
			return new Color32((byte)(Mathf.Clamp01(c.r) * 255f), (byte)(Mathf.Clamp01(c.g) * 255f), (byte)(Mathf.Clamp01(c.b) * 255f), (byte)(Mathf.Clamp01(c.a) * 255f));
		}

		public static implicit operator Color(Color32 c)
		{
			return new Color(c.r / 255f, c.g / 255f, c.b / 255f, c.a / 255f);
		}

		/// <summary>
		///   <para>Linearly interpolates between colors a and b by t.</para>
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <param name="t"></param>
		public static Color32 Lerp(Color32 a, Color32 b, float t)
		{
			t = Mathf.Clamp01(t);
			return new Color32((byte)(a.r + (b.r - a.r) * t), (byte)(a.g + (b.g - a.g) * t), (byte)(a.b + (b.b - a.b) * t), (byte)(a.a + (b.a - a.a) * t));
		}

		/// <summary>
		///   <para>Linearly interpolates between colors a and b by t.</para>
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <param name="t"></param>
		public static Color32 LerpUnclamped(Color32 a, Color32 b, float t)
		{
			return new Color32((byte)(a.r + (b.r - a.r) * t), (byte)(a.g + (b.g - a.g) * t), (byte)(a.b + (b.b - a.b) * t), (byte)(a.a + (b.a - a.a) * t));
		}

		/// <summary>
		///   <para>Returns a nicely formatted string of this color.</para>
		/// </summary>
		/// <param name="format"></param>
		public override string ToString()
		{
			return UnityString.Format("RGBA({0}, {1}, {2}, {3})", new object[]
			{
				r,
				g,
				b,
				a
			});
		}

		/// <summary>
		///   <para>Returns a nicely formatted string of this color.</para>
		/// </summary>
		/// <param name="format"></param>
		public string ToString(string format)
		{
			return UnityString.Format("RGBA({0}, {1}, {2}, {3})", new object[]
			{
				r.ToString(format),
				g.ToString(format),
				b.ToString(format),
				a.ToString(format)
			});
		}

		[FieldOffset(0)]
		private int rgba;

		/// <summary>
		///   <para>Red component of the color.</para>
		/// </summary>
		[FieldOffset(0)]
		public byte r;

		/// <summary>
		///   <para>Green component of the color.</para>
		/// </summary>
		[FieldOffset(1)]
		public byte g;

		/// <summary>
		///   <para>Blue component of the color.</para>
		/// </summary>
		[FieldOffset(2)]
		public byte b;

		/// <summary>
		///   <para>Alpha component of the color.</para>
		/// </summary>
		[FieldOffset(3)]
		public byte a;
	}
}
