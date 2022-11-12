using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
	public enum LineTextureMode
	{
		Stretch,
		Tile,
		DistributePerSegment,
		RepeatPerSegment
	}

	public enum LineAlignment
	{
		View,
		[Obsolete]
		Local,
		TransformZ = 1
	}

	public sealed class LineRenderer : Renderer
	{
		public LineRenderer(IntPtr ptr) : base(ptr) { }

		unsafe public float startWidth
		{
			get => Instance_Class.GetProperty(nameof(startWidth)).GetGetMethod().Invoke<float>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(startWidth)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public float endWidth
		{
			get => Instance_Class.GetProperty(nameof(endWidth)).GetGetMethod().Invoke<float>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(endWidth)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public float widthMultiplier
		{
			get => Instance_Class.GetProperty(nameof(widthMultiplier)).GetGetMethod().Invoke<float>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(widthMultiplier)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}
		unsafe public int numCornerVertices
		{
			get => Instance_Class.GetProperty(nameof(numCornerVertices)).GetGetMethod().Invoke<int>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(numCornerVertices)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public int numCapVertices
		{
			get => Instance_Class.GetProperty(nameof(numCapVertices)).GetGetMethod().Invoke<int>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(numCapVertices)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public bool useWorldSpace
		{
			get => Instance_Class.GetProperty(nameof(useWorldSpace)).GetGetMethod().Invoke<bool>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(useWorldSpace)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public bool loop
		{
			get => Instance_Class.GetProperty(nameof(loop)).GetGetMethod().Invoke<bool>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(loop)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public Color startColor
		{
			get => Instance_Class.GetProperty(nameof(startColor)).GetGetMethod().Invoke<Color>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(startColor)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public Color endColor
		{
			get => Instance_Class.GetProperty(nameof(endColor)).GetGetMethod().Invoke<Color>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(endColor)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public int positionCount
		{
			get => Instance_Class.GetProperty(nameof(positionCount)).GetGetMethod().Invoke<int>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(positionCount)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public void SetPosition(int index, Vector3 position)
		{
			Instance_Class.GetMethod(nameof(SetPosition)).Invoke(this, new IntPtr[] { new IntPtr(&index), new IntPtr(&position) });
		}

		unsafe public Vector3 GetPosition(int index)
		{
			return Instance_Class.GetMethod(nameof(GetPosition)).Invoke<Vector3>(this, new IntPtr[] { new IntPtr(&index) }).GetValue();
		}

		unsafe public float shadowBias
		{
			get => Instance_Class.GetProperty(nameof(shadowBias)).GetGetMethod().Invoke<float>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(shadowBias)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public bool generateLightingData
		{
			get => Instance_Class.GetProperty(nameof(generateLightingData)).GetGetMethod().Invoke<bool>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(generateLightingData)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public LineTextureMode textureMode
		{
			get => Instance_Class.GetProperty(nameof(textureMode)).GetGetMethod().Invoke<LineTextureMode>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(textureMode)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public LineAlignment alignment
		{
			get => Instance_Class.GetProperty(nameof(alignment)).GetGetMethod().Invoke<LineAlignment>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(alignment)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public void Simplify(float tolerance)
		{
			Instance_Class.GetMethod(nameof(Simplify)).Invoke(this, new IntPtr[] { new IntPtr(&tolerance) });
		}

		/*public void BakeMesh(Mesh mesh, bool useTransform = false)
		{
			Instance_Class.GetMethod(nameof(BakeMesh), x => x.GetParameters().Length == 2).Invoke(this, new IntPtr[] { })
		}

		public void BakeMesh([NotNull] Mesh mesh, [NotNull] Camera camera, bool useTransform = false)
		{
			if (mesh == null) return;
			if (camera == null) return;
		}
		*/

		public void SetPositions(Vector3[] positions)
		{
			if (positions == null) return;
			int len = positions.Length;
			IL2Array<Vector3> vectorArray = new IL2Array<Vector3>(len, Vector3.Instance_Class);
            for (int i = 0; i < len; i++)
            {
				vectorArray[i] = positions[i];
			}
			Instance_Class.GetMethod(nameof(SetPositions)).Invoke(this, new IntPtr[] { vectorArray == null ? IntPtr.Zero : vectorArray.Pointer });
		}


		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("LineRenderer", "UnityEngine");
	}
}
