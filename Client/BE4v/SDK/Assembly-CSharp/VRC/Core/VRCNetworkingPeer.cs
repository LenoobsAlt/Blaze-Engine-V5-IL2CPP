using System;
using System.Linq;
using IL2CPP_Core.Objects;
using IL2Photon.Realtime;

namespace VRC.Core
{
    public class VRCNetworkingPeer : LoadBalancingPeer
    {
        public VRCNetworkingPeer(IntPtr ptr) : base(ptr) { }

        public static VRCNetworkingPeer Instance
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(Instance));
                if (field == null)
                    (field = Instance_Class.GetField(x => x.Instance)).Name = nameof(Instance);
                return field?.GetValue()?.GetValue<VRCNetworkingPeer>();
            }
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("SendOutgoingCommands") != null);
    }
}