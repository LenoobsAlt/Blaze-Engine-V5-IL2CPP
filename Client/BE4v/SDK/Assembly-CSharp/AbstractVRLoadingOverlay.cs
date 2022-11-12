using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public abstract class AbstractVRLoadingOverlay : MonoBehaviour
{
    public AbstractVRLoadingOverlay(IntPtr ptr) : base(ptr) { }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetField("worldImageMask") != null);
}