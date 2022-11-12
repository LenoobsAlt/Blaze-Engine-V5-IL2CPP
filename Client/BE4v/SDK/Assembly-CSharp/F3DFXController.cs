using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public class F3DFXController : MonoBehaviour
{
    public F3DFXController(IntPtr ptr) : base(ptr) { }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("Awake") != null && x.GetMethod("OnGUI") != null && x.Pointer != OVRLipSyncMicInput.Instance_Class.Pointer);
}