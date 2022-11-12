using System;
using IL2CPP_Core.Objects;

namespace UnityEngine.Events
{
    public class UnityEventBase : IL2Object
    {
        public UnityEventBase(IntPtr ptr) : base(ptr) { }

        public void RemoveAllListeners()
        {
            Instance_Class.GetMethod(nameof(RemoveAllListeners)).Invoke(this);
        }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("UnityEventBase", "UnityEngine.Events");
    }
}
