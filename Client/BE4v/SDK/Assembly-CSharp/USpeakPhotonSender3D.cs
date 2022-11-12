using System;
using System.Linq;
using IL2CPP_Core.Objects;

public class USpeakPhotonSender3D : VRCNetworkBehaviour
{
    public USpeakPhotonSender3D(IntPtr ptr) : base(ptr) { }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("InformOfBadConnection") != null);
}