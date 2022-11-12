using System;
using IL2CPP_Core.Objects;
using UnityEngine;

public class CC_Base : MonoBehaviour
{
    public CC_Base(IntPtr ptr) : base(ptr) { }

	public static new IL2Class Instance_Class = CC_Glitch.Instance_Class.BaseType;
}