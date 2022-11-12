using System;
using IL2CPP_Core.Objects;
using VRC;
using VRC.Udon;
using UnityEngine;
using BE4v.SDK;
using BE4v.Patch.Core;
using VRC.SDKBase;

namespace BE4v.Patch.List
{
    public class GlobalUdonEvents // : IPatch
    {
        public delegate void _SendCustomEvent(IntPtr instance, IntPtr eventName);
        public delegate void _UdonSyncRunProgramAsRPC(IntPtr eventName, IntPtr instigator);
        public void Start()
        {
            IL2Method method = UdonBehaviour.Instance_Class.GetMethod("SendCustomEvent");
            if (method != null)
            {
                patch[0] = new IL2Patch(method, (_SendCustomEvent)SendCustomEvent);
                _delegateSendCustomEvent = patch[0].CreateDelegate<_SendCustomEvent>();
            }
            else
                throw new NullReferenceException(nameof(GlobalUdonEvents) + "::" + nameof(SendCustomEvent));

            method = null;
            method = VRC.Networking.UdonSync.Instance_Class.GetMethod("UdonSyncRunProgramAsRPC");
            if (method != null)
            {
                patch[1] = new IL2Patch(method, (_UdonSyncRunProgramAsRPC)UdonSyncRunProgramAsRPC);
            }
            else
                throw new NullReferenceException(nameof(GlobalUdonEvents) + "::" + nameof(UdonSyncRunProgramAsRPC));
        }

        public static void SendCustomEvent(IntPtr instance, IntPtr eventName)
        {
            if (instance == IntPtr.Zero || eventName == IntPtr.Zero) return;
            UdonBehaviour udon = new UdonBehaviour(instance);
            string nameEvent = new IL2String(eventName).ToString();
            GameObject gameObject = udon.gameObject;
            if (gameObject != null)
            {
                Network.RPC(VRC_EventHandler.VrcTargetType.All, gameObject, "UdonSyncRunProgramAsRPC", new IntPtr[] { eventName });
            }
            try
            {
                _delegateSendCustomEvent(instance, eventName);
            }
            catch { }
        }
        
        public static void UdonSyncRunProgramAsRPC(IntPtr instance, IntPtr eventName)
        {
        }

        public static IL2Patch[] patch = new IL2Patch[2];

        public static _SendCustomEvent _delegateSendCustomEvent = null;
    }
}
