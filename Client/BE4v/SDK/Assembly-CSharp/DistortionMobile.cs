using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public class DistortionMobile : MonoBehaviour
{
    public DistortionMobile(IntPtr ptr) : base(ptr) { }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("OnBecameVisible") != null && x.GetMethod("Update") != null);
}