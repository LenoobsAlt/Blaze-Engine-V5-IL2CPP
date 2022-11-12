using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public class SDK2UrlLauncher : MonoBehaviour
{
    public SDK2UrlLauncher(IntPtr ptr) : base(ptr) { }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["acs"].GetClass("SDK2UrlLauncher");
}