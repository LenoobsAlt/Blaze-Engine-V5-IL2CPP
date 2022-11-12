using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public class VRCUiPage : MonoBehaviour
{
    public VRCUiPage(IntPtr ptr) : base(ptr) { }

    public static new IL2Class Instance_Class = VRCUiPopup.Instance_Class.BaseType;
}