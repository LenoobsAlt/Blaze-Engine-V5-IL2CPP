using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public class VRCUiPlaylists : VRCUiPageWorlds
{
    public VRCUiPlaylists(IntPtr ptr) : base(ptr) { }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.BaseType != MonoBehaviour.Instance_Class && x.GetMethod("BackToPreviousScreen") != null);
}