using System;
using IL2CPP_Core.Objects;

namespace VRC.Core
{
    public class ApiModelContainer<T> : ApiDictContainer where T : ApiModel
    {
        public ApiModelContainer(IntPtr ptr) : base(ptr) { }

        public ApiModelContainer() : base(IntPtr.Zero)
        {
            Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
            IL2Method method = Instance_Class.GetMethod(".ctor", x => x.GetParameters().Length == 0);
            method.Invoke(Pointer, new IntPtr[] { method.Pointer });
        }

        public ApiModelContainer(T target) : base(IntPtr.Zero)
        {
            Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
            IL2Method method = Instance_Class.GetMethod(".ctor", x => x.GetParameters().Length == 1);
            method.Invoke(Pointer, new IntPtr[] { target.Pointer, method.Pointer });
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["VRCCore-Standalone"].GetClass("ApiModelContainer`1", "VRC.Core"); //.MakeGenericType(new Type[] { typeof(T) });
    }
}
