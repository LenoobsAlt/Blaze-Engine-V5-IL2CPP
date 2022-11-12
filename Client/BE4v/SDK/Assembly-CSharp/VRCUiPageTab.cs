using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public class VRCUiPageTab : MonoBehaviour
{
    public VRCUiPageTab(IntPtr ptr) : base(ptr) { }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["acs"].GetClasses().FirstOrDefault(x => x.GetMethod("ShowPage") != null);
}