using System;
using IL2CPP_Core.Objects;

namespace System
{
    public class IL2ObjectSystem : IL2Object
    {
        public IL2ObjectSystem(IntPtr ptr) : base(ptr) => Pointer = ptr;

        public new string ToString()
        {
            return Instance_Class.GetMethod(nameof(ToString)).Invoke(this)?.GetValue<IL2String>().ToString();
        }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass(typeof(object).Name, typeof(object).Namespace);
    }
}
