using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public class EffectSettings : MonoBehaviour
{
    public EffectSettings(IntPtr ptr) : base(ptr) { }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("Deactivate") != null && x.GetMethod("OnEnable") != null && string.IsNullOrEmpty(x.Namespace));
}