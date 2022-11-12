using System;
using System.Linq;
using IL2CPP_Core.Objects;

namespace System
{
    public class RuntimeType : IL2Object
    {
        public RuntimeType(IntPtr ptr) : base(ptr) { }

        public IntPtr MakeGenericType(Type[] types) => MakeGenericType(types.Select(x => x.IL2Typeof()).ToArray());
        public IntPtr MakeGenericType(IntPtr[] intPtrs)
        {
            int len = intPtrs.Length;
            IL2Array<IntPtr> array = new IL2Array<IntPtr>(len, IL2Type.Instance_Class);
            for(int i=0;i<len; i++)
            {
                array[i] = intPtrs[i];
            }
            return Import.Class.il2cpp_class_from_system_type(Instance_Class.GetMethod(nameof(MakeGenericType)).Invoke(new IL2Class(Pointer).IL2Typeof(), new IntPtr[] { array.Pointer }).Pointer);
        }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass(typeof(RuntimeType).Name, typeof(RuntimeType).Namespace);
    }
}
