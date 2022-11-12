using System;

namespace IL2CPP_Core.Objects
{
    public class IL2Param : IL2Object
    {
        public string Name { get; private set; }
        internal IL2Param(IntPtr ptr, string name) : base(ptr)
        {
            Pointer = ptr;
            Name = name;
        }
        public IL2ClassType ReturnType => new IL2ClassType(Pointer);
    }
}
