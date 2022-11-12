using System;
using IL2CPP_Core.Objects;

namespace VRC.Core
{
    public class ApiContainer : IL2Object
    {
        public ApiContainer(IntPtr ptr) : base(ptr) { }

        public ApiContainer() : base(IntPtr.Zero)
        {
            Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
            Instance_Class.GetMethod(".ctor").Invoke(Pointer);
        }

        /*
        // Action<ApiContainer>
        public Delegate OnError
        {
            // get => Instance_Class.GetField(nameof(OnError)).GetValue(ptr);
            set => Instance_Class.GetField(nameof(OnError)).SetValue(ptr, _UnityAction.CreateDelegate(value, IntPtr.Zero, BlazeTools.IL2SystemClass.action));
        }

        public Delegate OnSuccess
        {
            // get => Instance_Class.GetField(nameof(OnSuccess)).GetValue(ptr).ptr;
            set => Instance_Class.GetField(nameof(OnSuccess)).SetValue(ptr, _UnityAction.CreateDelegate(value, IntPtr.Zero, BlazeTools.IL2SystemClass.action));
        }
        */

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["VRCCore-Standalone"].GetClass("ApiContainer", "VRC.Core");
    }
}
