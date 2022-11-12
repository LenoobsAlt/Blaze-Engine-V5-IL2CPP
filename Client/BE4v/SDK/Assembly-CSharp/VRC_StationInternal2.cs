using System;
using System.Linq;
using IL2CPP_Core.Objects;

public class VRC_StationInternal2 : VRC_StationInternal
{
    public VRC_StationInternal2(IntPtr ptr) : base(ptr) { }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.BaseType == VRC_StationInternal.Instance_Class && x.GetMethod("ProvideEvents") != null);
}