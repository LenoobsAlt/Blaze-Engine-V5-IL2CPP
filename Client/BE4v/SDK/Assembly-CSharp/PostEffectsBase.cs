using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public class PostEffectsBase : MonoBehaviour
{
    public PostEffectsBase(IntPtr ptr) : base(ptr) { }

    public static new IL2Class Instance_Class = HighlightsFX.Instance_Class.BaseType;
}
