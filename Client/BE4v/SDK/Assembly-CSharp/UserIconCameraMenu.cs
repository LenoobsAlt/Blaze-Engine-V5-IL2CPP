using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public class UserIconCameraMenu : VRCNetworkBehaviour
{
    public UserIconCameraMenu(IntPtr ptr) : base(ptr) { }
    
    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["acs"].GetClasses().FirstOrDefault(x => x.GetMethod("FlipDirection") != null);
}