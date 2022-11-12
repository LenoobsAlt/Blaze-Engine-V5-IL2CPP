using System;
using System.Linq;
using IL2CPP_Core.Objects;

public class VRCUiPageWorlds : VRCSearchableUiPage
{
    public VRCUiPageWorlds(IntPtr ptr) : base(ptr) { }

    public static new IL2Class Instance_Class = VRCUiPlaylists.Instance_Class.BaseType;
}