using System;
using IL2CPP_Core.Objects;

namespace System.IO
{
    public abstract class IL2Stream : IL2Object
    {
        public IL2Stream(IntPtr ptr) : base(ptr) { }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass(typeof(Stream).Name, typeof(Stream).Namespace);
    }
}
