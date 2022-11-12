using System;
using IL2CPP_Core.Objects;
using BE4v.Patch.Core;

namespace BE4v.Patch.List
{
    public class VRCNetworkingClient // : IPatch
    {
        public delegate void _VRCNetworkingClient_OnEvent(IntPtr instance, IntPtr pEventData);
        public void Start()
        {
            IL2Method method = VRC.Core.VRCNetworkingClient.Instance_Class.GetMethod("OnEvent");
            if (method == null)
                throw new NullReferenceException();
            
            _OnEvent = PatchUtils.FastPatch<_VRCNetworkingClient_OnEvent>(method, VRCNetworkingClient_OnEvent);
        }

        public static void VRCNetworkingClient_OnEvent(IntPtr instance, IntPtr pEventData)
        {
            try
            {
                if (NetworkSanity.NetworkSanity.VRCNetworkingClient.OnEvent(pEventData))
                    _OnEvent(instance, pEventData);
            }
            catch { }
        }

        public static _VRCNetworkingClient_OnEvent _OnEvent;
    }
}