using System;
using IL2CPP_Core.Objects;
using BE4v.SDK;
using IL2Photon.Pun;

namespace BE4v.Patch.List
{
    public class OnMasterClientSwitched // : IPatch
    {
        public delegate void _OnMasterClientSwitched(IntPtr instance, IntPtr newMasterClient);

        public void Start()
        {
            IL2Method method = PhotonHandler.Instance_Class.GetMethod("OnMasterClientSwitched");
            if (method == null)
                throw new NullReferenceException();

            patch = new IL2Patch(method, (_OnMasterClientSwitched)___OnMasterClientSwitched);
            __OnMasterClientSwitched = patch.CreateDelegate<_OnMasterClientSwitched>();
        }

        public static void ___OnMasterClientSwitched(IntPtr instance, IntPtr newMasterClient)
        {
            if (instance == IntPtr.Zero)
                return;
            if (newMasterClient != IntPtr.Zero)
            {
                IL2Photon.Realtime.Player player = new IL2Photon.Realtime.Player(newMasterClient);
                VRC.PlayerManager.MasterId = player.ActorNumber;
                ("New master Instance: " + VRC.PlayerManager.MasterId).RedPrefix("Debug");
            }
            __OnMasterClientSwitched(instance, newMasterClient);
        }

        public static IL2Patch patch;

        public static _OnMasterClientSwitched __OnMasterClientSwitched;
    }
}
