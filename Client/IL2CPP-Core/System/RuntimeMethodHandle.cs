using System;
using IL2CPP_Core.Objects;

namespace System
{
    public class IL2RuntimeMethodHandle : IL2Object
    {
        public IL2RuntimeMethodHandle(IntPtr ptr) : base(ptr) { }

        unsafe public IntPtr value
        {
            get => Instance_Class.GetField(nameof(value)).GetValue<IntPtr>(this).GetValue();
            set => Instance_Class.GetField(nameof(value)).SetValue(this, new IntPtr(&value));
        }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass(typeof(RuntimeMethodHandle).Name, typeof(RuntimeMethodHandle).Namespace);
    }
}
