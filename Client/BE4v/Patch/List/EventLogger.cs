using System;
using System.Linq;
using BE4v.Mods;
using BE4v.SDK;
using BE4v.Patch.Core;
using VRC.SDKBase;

namespace BE4v.Patch.List
{
    public static class EventLogger
    {
        public delegate void _TriggerEvent(IntPtr instance, IntPtr handler, IntPtr e, VRC_EventHandler.VrcBroadcastType broadcast, int instagatorId, float fastForward);
        public static void Start()
        {
            /*
            try
            {
                IL2Method method = VRC_EventDispatcherRFC.Instance_Class.GetMethod("TriggerEvent");
                patch = new IL2Patch(method, (_TriggerEvent)TriggerEvent);
                _delegateTriggerEvent = patch.CreateDelegate<_TriggerEvent>();
                "Event Logger".GreenPrefix(TMessage.SuccessPatch);
            }
            catch
            {
                "Event Logger".RedPrefix(TMessage.BadPatch);
            }
            /*
            try
            {
                IL2Method method = VRC.Udon.UdonBehaviour.Instance_Class.GetMethod("SendCustomEvent");
                patch2 = new IL2Patch(method, (_SendCustomEvent)SendCustomEvent);
                _delegateSendCustomEvent = patch2.CreateDelegate<_SendCustomEvent>();
                "Event Logger Udon".GreenPrefix(TMessage.SuccessPatch);
            }
            catch
            {
                "Event Logger Udon".RedPrefix(TMessage.BadPatch);
            }
            */
        }

        public static void TriggerEvent(IntPtr instance, IntPtr handler, IntPtr e, VRC_EventHandler.VrcBroadcastType broadcast, int instagatorId, float fastForward)
        {
            VRC_EventHandler.VrcEvent vrcEvent = new VRC_EventHandler.VrcEvent(e);
            
            if (Status.isRPCLogger)
            {
                Console.WriteLine($"=== [RPC by {instagatorId}] ===");
                Console.WriteLine($"* Broadcast: " + broadcast);
                Console.WriteLine($"* TargetType: " + (VRC_EventHandler.VrcTargetType)vrcEvent.ParameterInt);
                Console.WriteLine($"* GameObject: " + vrcEvent.ParameterObject.name);
                Console.WriteLine($"* RPC Message: " + vrcEvent.ParameterString);
            }
            try
            {
                _delegateTriggerEvent(instance, handler, e, broadcast, instagatorId, fastForward);
            }
            catch { }
        }

        /*
        public static void SendCustomEvent(IntPtr instance, IntPtr eventName)
        {
            Console.WriteLine("UDON LOG: " + new IL2String(eventName));
            try
            {
                _delegateSendCustomEvent(instance, eventName);
            }
            catch { }
        }
        */
        public static IL2Patch patch;
        public static IL2Patch patch2;

        public static _TriggerEvent _delegateTriggerEvent = null;
        // public static _SendCustomEvent _delegateSendCustomEvent = null;
    }
}
