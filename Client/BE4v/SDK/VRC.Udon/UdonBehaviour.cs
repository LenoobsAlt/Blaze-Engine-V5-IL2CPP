using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;
using VRC.Udon.Common.Interfaces;
using VRC.Udon.Common.Enums;

namespace VRC.Udon
{
    public class UdonBehaviour : MonoBehaviour
    {
        public UdonBehaviour(IntPtr ptr) : base(ptr) { }

        unsafe public void SendCustomNetworkEvent(NetworkEventTarget target, string eventName)
        {
            Instance_Class.GetMethod(nameof(SendCustomNetworkEvent)).Invoke(this, new IntPtr[] { new IntPtr(&target), new IL2String_utf16(eventName).Pointer });
        }
        
        unsafe public void SendCustomEvent(string eventName)
        {
            Instance_Class.GetMethod(nameof(SendCustomEvent)).Invoke(this, new IntPtr[] { new IL2String_utf16(eventName).Pointer });
        }

        public string[] GetPrograms()
        {
            IL2Object result = Instance_Class.GetMethod(nameof(GetPrograms)).Invoke(this);
            if (result == null)
                return null;
            return new IL2Array<IntPtr>(result.Pointer).ToArray<IL2String>().Select(x => x.ToString()).ToArray();
         }

        unsafe public void SendCustomEventDelayedSeconds(string eventName, float delaySeconds, EventTiming eventTiming = EventTiming.Update)
        {
            Instance_Class.GetMethod(nameof(SendCustomEventDelayedSeconds)).Invoke(this, new IntPtr[] { new IL2String_utf16(eventName).Pointer, new IntPtr(&delaySeconds), new IntPtr(&eventTiming) });
        }

        unsafe public void SendCustomEventDelayedFrames(string eventName, int delayFrames, EventTiming eventTiming = EventTiming.Update)
        {
            Instance_Class.GetMethod(nameof(SendCustomEventDelayedFrames)).Invoke(this, new IntPtr[] { new IL2String_utf16(eventName).Pointer, new IntPtr(&delayFrames), new IntPtr(&eventTiming) });
        }

        unsafe public bool DisableInteractive
        {
            get => Instance_Class.GetProperty(nameof(DisableInteractive)).GetGetMethod().Invoke<bool>(this).GetValue();
            set => Instance_Class.GetProperty(nameof(DisableInteractive)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
        }

        public bool IsInteractive
        {
            get => Instance_Class.GetProperty(nameof(IsInteractive)).GetGetMethod().Invoke<bool>(this).GetValue(); 
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["VRC.Udon"].GetClass("UdonBehaviour", "VRC.Udon");
    }
}
