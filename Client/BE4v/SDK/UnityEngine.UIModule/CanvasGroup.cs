using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
	public sealed class CanvasGroup : Behaviour
	{
		public CanvasGroup(IntPtr ptr) : base(ptr) { }

		public CanvasGroup() : base(IntPtr.Zero)
		{
			Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
			Instance_Class.GetMethod(".ctor").Invoke(Pointer);
		}

		unsafe public float alpha
		{
			get => Instance_Class.GetProperty(nameof(alpha)).GetGetMethod().Invoke<float>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(alpha)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public bool interactable
		{
			get => Instance_Class.GetProperty(nameof(interactable)).GetGetMethod().Invoke<bool>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(interactable)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public bool blocksRaycasts
		{
			get => Instance_Class.GetProperty(nameof(blocksRaycasts)).GetGetMethod().Invoke<bool>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(blocksRaycasts)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public bool ignoreParentGroups
		{
			get => Instance_Class.GetProperty(nameof(ignoreParentGroups)).GetGetMethod().Invoke<bool>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(ignoreParentGroups)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
		{
			return Instance_Class.GetMethod(nameof(IsRaycastLocationValid)).Invoke<bool>(this, new IntPtr[] { new IntPtr(&sp), (eventCamera == null) ? IntPtr.Zero : eventCamera.Pointer }).GetValue();
		}

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.UIModule"].GetClass("CanvasGroup", "UnityEngine");
	}
}
