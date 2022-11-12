using System;
using System.Linq;
using UnityEngine;
using IL2CPP_Core.Objects;

public abstract class VRCNetworkBehaviour : MonoBehaviour
{
    public VRCNetworkBehaviour(IntPtr ptr) : base(ptr) { }

    public static new IL2Class Instance_Class = VRCPlayer.Instance_Class.BaseType;
}