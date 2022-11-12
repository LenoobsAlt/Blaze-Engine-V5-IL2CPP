using IL2CPP_Core.Objects;

namespace System
{
    public class IL2Byte : IL2Object
    {
        public IL2Byte(IntPtr ptr) : base(ptr) { }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass(typeof(byte).Name, typeof(byte).Namespace);
    }
}
