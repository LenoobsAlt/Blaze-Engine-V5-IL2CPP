using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public class SlowTransformEditor : MonoBehaviour
{
	public SlowTransformEditor(IntPtr ptr) : base(ptr) { }

	public void SwapTransform(Transform A, Transform B)
	{
		Instance_Class.GetMethod(nameof(SwapTransform)).Invoke(this, new IntPtr[] { A.Pointer, B.Pointer });
	}

	public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("SwapTransform") != null);
}