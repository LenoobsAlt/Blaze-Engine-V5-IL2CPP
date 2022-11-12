using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public class DynamicBoneCollider : MonoBehaviour
{
	public DynamicBoneCollider(IntPtr ptr) : base(ptr) { }

	unsafe public Bound m_Bound
    {
        get => Instance_Class.GetField(nameof(m_Bound)).GetValue<Bound>(this).GetValue();
		set => Instance_Class.GetField(nameof(m_Bound)).SetValue(this, new IntPtr(&value));
    }

	public enum Direction
	{
		X,
		Y,
		Z
	}

	public enum Bound
	{
		Outside,
		Inside
	}

	public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClass("DynamicBoneCollider");
}
