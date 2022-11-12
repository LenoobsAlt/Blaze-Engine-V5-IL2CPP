using System;
using System.Linq;
using IL2CPP_Core.Objects;
using IL2Photon.Realtime;

namespace VRC.Core
{
    public class VRCNetworkingClient : LoadBalancingClient
    {
        public VRCNetworkingClient(IntPtr ptr) : base(ptr) { }

        public static VRCNetworkingClient Instance
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(Instance));
                if (field == null)
                    (field = Instance_Class.GetField(x => x.Instance)).Name = nameof(Instance);
                return field?.GetValue()?.GetValue<VRCNetworkingClient>();
            }
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().First(x => x.GetField(y => y.Instance) != null && x.GetMethod("OnEvent") != null);
    }
}