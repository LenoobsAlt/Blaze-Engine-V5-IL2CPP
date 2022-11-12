using System;
using System.Linq;
using IL2CPP_Core.Objects;

public class VRC_PlayerAudioOverrideInternal : VRCNetworkBehaviour
{
    public VRC_PlayerAudioOverrideInternal(IntPtr ptr) : base(ptr) { }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("InternalApplyOverrideRPC") != null);
}