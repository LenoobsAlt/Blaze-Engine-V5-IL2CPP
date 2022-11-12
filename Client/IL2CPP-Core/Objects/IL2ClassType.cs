using System;

namespace IL2CPP_Core.Objects
{
    public class IL2ClassType : IL2Object
    {
        internal IL2ClassType(IntPtr ptr) : base(ptr) { }

        public string Name
        {
            get => Import.Object.il2cpp_type_get_name(Pointer);
        }
    }
}
