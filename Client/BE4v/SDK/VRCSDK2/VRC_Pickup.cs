using System;
using IL2CPP_Core.Objects;

namespace VRCSDK2
{
    public class VRC_Pickup : VRC.SDKBase.VRC_Pickup
    {
        public VRC_Pickup(IntPtr ptr) : base(ptr) { }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["VRCSDK2"].GetClass("VRC_Pickup", "VRCSDK2");
    }
}
