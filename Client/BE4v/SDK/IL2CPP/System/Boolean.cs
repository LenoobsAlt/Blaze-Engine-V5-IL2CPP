using IL2CPP_Core.Objects;

namespace System
{
    public class IL2Boolean : IL2Object
    {
        public IL2Boolean(IntPtr ptr) : base(ptr) { }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass(typeof(bool).Name, typeof(bool).Namespace);
    }
}
