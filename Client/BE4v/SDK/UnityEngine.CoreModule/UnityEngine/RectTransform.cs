using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
    public class RectTransform : Transform
    {
        public RectTransform(IntPtr ptr) : base(ptr) { }
		/*
		public static event ReapplyDrivenProperties reapplyDrivenProperties
		{
			add
			{
			}
			remove
			{
			}
		}
		*/
		public Rect rect
		{
			get => Instance_Class.GetProperty(nameof(rect)).GetGetMethod().Invoke<Rect>(this).GetValue();
		}

		unsafe public Vector2 anchorMin
		{
			get => Instance_Class.GetProperty(nameof(anchorMin)).GetGetMethod().Invoke<Vector2>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(anchorMin)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public Vector2 anchorMax
		{
			get => Instance_Class.GetProperty(nameof(anchorMax)).GetGetMethod().Invoke<Vector2>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(anchorMax)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public Vector2 anchoredPosition
		{
			get => Instance_Class.GetProperty(nameof(anchoredPosition)).GetGetMethod().Invoke<Vector2>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(anchoredPosition)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public Vector2 sizeDelta
		{
			get => Instance_Class.GetProperty(nameof(sizeDelta)).GetGetMethod().Invoke<Vector2>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(sizeDelta)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public Vector2 pivot
		{
			get => Instance_Class.GetProperty(nameof(pivot)).GetGetMethod().Invoke<Vector2>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(pivot)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public Vector3 anchoredPosition3D
		{
			get => Instance_Class.GetProperty(nameof(anchoredPosition3D)).GetGetMethod().Invoke<Vector3>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(anchoredPosition3D)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public Vector2 offsetMin
		{
			get => Instance_Class.GetProperty(nameof(offsetMin)).GetGetMethod().Invoke<Vector2>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(offsetMin)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public Vector2 offsetMax
		{
			get => Instance_Class.GetProperty(nameof(offsetMax)).GetGetMethod().Invoke<Vector2>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(offsetMax)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		public Object drivenByObject
		{
			get => Instance_Class.GetProperty(nameof(drivenByObject)).GetGetMethod().Invoke(this)?.GetValue<Object>();
			set => Instance_Class.GetProperty(nameof(drivenByObject)).GetSetMethod().Invoke(this, new IntPtr[] { value == null ? IntPtr.Zero : value.Pointer });
		}

		unsafe internal DrivenTransformProperties drivenProperties
		{
			get => Instance_Class.GetProperty(nameof(drivenProperties)).GetGetMethod().Invoke<DrivenTransformProperties>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(drivenProperties)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		public void ForceUpdateRectTransforms()
		{
			Instance_Class.GetMethod(nameof(ForceUpdateRectTransforms)).Invoke(this);
		}
		/*
		public void GetLocalCorners(Vector3[] fourCornersArray)
		{
		}

		public void GetWorldCorners(Vector3[] fourCornersArray)
		{
		}
		*/
		unsafe public void SetInsetAndSizeFromParentEdge(Edge edge, float inset, float size)
		{
			Instance_Class.GetMethod(nameof(SetInsetAndSizeFromParentEdge)).Invoke(this, new IntPtr[] { new IntPtr(&edge), new IntPtr(&inset), new IntPtr(&size) });
		}

		unsafe public void SetSizeWithCurrentAnchors(Axis axis, float size)
		{
			Instance_Class.GetMethod(nameof(SetSizeWithCurrentAnchors)).Invoke(this, new IntPtr[] { new IntPtr(&axis), new IntPtr(&size) });
		}

		public static void SendReapplyDrivenProperties(RectTransform driven)
		{
			Instance_Class.GetMethod(nameof(SendReapplyDrivenProperties)).Invoke(new IntPtr[] { driven == null ? IntPtr.Zero : driven.Pointer });
		}

		public Rect GetRectInParentSpace()
		{
			return Instance_Class.GetMethod(nameof(GetRectInParentSpace)).Invoke<Rect>(this).GetValue();
		}

		public Vector2 GetParentSize()
		{
			return Instance_Class.GetMethod(nameof(GetParentSize)).Invoke<Vector2>(this).GetValue();
		}

		public enum Edge
		{
			Left,
			Right,
			Top,
			Bottom
		}

		public enum Axis
		{
			Horizontal,
			Vertical
		}

		public delegate void ReapplyDrivenProperties(RectTransform driven);
		
		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("RectTransform", "UnityEngine");
    }
}
