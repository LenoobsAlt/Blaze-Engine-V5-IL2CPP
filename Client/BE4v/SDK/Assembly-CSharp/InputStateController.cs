using System;
using IL2CPP_Core.Objects;
using UnityEngine;

public abstract class InputStateController : MonoBehaviour
{
    public InputStateController(IntPtr ptr) : base(ptr) { }

    public static new IL2Class Instance_Class = LocomotionInputController.Instance_Class.BaseType;
}