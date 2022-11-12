using System;
using IL2CPP_Core.Objects;

namespace VRCSDK2
{
    public class VRC_Station : VRC.SDKBase.VRCStation
    {
        public VRC_Station(IntPtr ptr) : base(ptr) { }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["VRCSDK2"].GetClass("VRC_Station", "VRCSDK2");
    }
}
