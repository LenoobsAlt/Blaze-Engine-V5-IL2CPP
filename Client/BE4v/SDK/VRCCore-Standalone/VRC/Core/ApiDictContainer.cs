using System;
using IL2CPP_Core.Objects;

namespace VRC.Core
{
    public class ApiDictContainer : ApiContainer
    {
        public ApiDictContainer(IntPtr ptr) : base(ptr) { }

        public ApiDictContainer() : base(IntPtr.Zero)
        {
            Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
            Instance_Class.GetMethod(".ctor").Invoke(Pointer);
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["VRCCore-Standalone"].GetClass("ApiDictContainer", "VRC.Core");
    }
}
