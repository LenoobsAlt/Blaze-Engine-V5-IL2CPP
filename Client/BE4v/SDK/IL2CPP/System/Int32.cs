using IL2CPP_Core.Objects;

namespace System
{
    public class IL2Int32 : IL2Object
    {
        public IL2Int32(IntPtr ptr) : base(ptr) { }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass(typeof(bool).Name, typeof(bool).Namespace);
    }
}
