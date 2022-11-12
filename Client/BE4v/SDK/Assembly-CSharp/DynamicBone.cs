using System;
using System.Collections.Generic;
using IL2CPP_Core.Objects;
using UnityEngine;

public class DynamicBone : MonoBehaviour
{
	public DynamicBone(IntPtr ptr) : base(ptr) { }

	public IL2ListObject<DynamicBoneCollider> m_Colliders
	{
		get
		{
			IL2Object result = Instance_Class.GetField(nameof(m_Colliders)).GetValue(this);
			if (result == null)
				return null;

			return new IL2ListObject<DynamicBoneCollider>(result.Pointer);
		}
		set => Instance_Class.GetField(nameof(m_Colliders)).SetValue(this, value.Pointer);
	}

	public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClass("DynamicBone");
}
