using System;
using IL2CPP_Core.Objects;

namespace System.Reflection
{
    public class IL2Module : IL2Object
    {
        public IL2Module(IntPtr ptr) : base(ptr) { }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass(typeof(Module).Name, typeof(Module).Namespace);
    }
}
