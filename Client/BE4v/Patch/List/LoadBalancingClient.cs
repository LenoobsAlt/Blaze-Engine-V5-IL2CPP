using System;
using IL2CPP_Core.Objects;
using BE4v.Patch.Core;

namespace BE4v.Patch.List
{
    public class LoadBalancingClient // : IPatch
    {
        public delegate void _LoadBalancingClient_OnEvent(IntPtr instance, IntPtr pEventData);
        public void Start()
        {
            IL2Method method = IL2Photon.Realtime.LoadBalancingClient.Instance_Class.GetMethod("OnEvent");
            if (method == null)
                throw new NullReferenceException();
            
            _OnEvent = PatchUtils.FastPatch<_LoadBalancingClient_OnEvent>(method, LoadBalancingClient_OnEvent);
        }

        public static void LoadBalancingClient_OnEvent(IntPtr instance, IntPtr pEventData)
        {
            try
            {
                if (NetworkSanity.NetworkSanity.LoadBalancingClient.OnEvent(pEventData))
                    _OnEvent(instance, pEventData);
            }
            catch { }
        }
        
        public static _LoadBalancingClient_OnEvent _OnEvent;
    }
}
