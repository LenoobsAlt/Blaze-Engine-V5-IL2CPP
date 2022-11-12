using System;
using IL2CPP_Core.Objects;
using BE4v.Patch.Core;

namespace BE4v.Patch.List
{
    public class PhotonNetwork //: IPatch
    {
        public delegate void _PhotonNetwork_OnEvent(IntPtr pEventData);
        public void Start()
        {
            IL2Method method = IL2Photon.Pun.PhotonNetwork.Instance_Class.GetMethod("OnEvent");
            if (method == null)
                throw new NullReferenceException();

            _OnEvent = PatchUtils.FastPatch<_PhotonNetwork_OnEvent>(method, PhotonNetwork_OnEvent);
        }

        public static void PhotonNetwork_OnEvent(IntPtr pEventData)
        {
            try
            {
                if (NetworkSanity.NetworkSanity.PhotonNetwork.OnEvent(pEventData))
                    _OnEvent(pEventData);
            }
            catch { }
        }
        
        public static _PhotonNetwork_OnEvent _OnEvent;
    }
}
