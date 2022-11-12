using System;
using IL2CPP_Core.Objects;

namespace UnityEngine.Events
{
    public class UnityEvent : UnityEventBase
    {
        public UnityEvent(IntPtr ptr) : base(ptr) { }


        public void AddListener(UnityAction action)
        {
            IL2Delegate @delegate = IL2Delegate.CreateDelegate(action, IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("UnityAction", "UnityEngine.Events"));
            Instance_Class.GetMethod("AddListener").Invoke(this, new IntPtr[] { @delegate == null ? IntPtr.Zero : @delegate.Pointer });
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("UnityEvent", "UnityEngine.Events");
    }
}
