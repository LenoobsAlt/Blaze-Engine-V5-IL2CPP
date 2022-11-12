using IL2CPP_Core.Objects;

namespace System
{
    unsafe public class IL2Action : IL2Object
    {
        public IL2Action(IntPtr ptr) : base(ptr) { }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass("Action", "System");
    }

    unsafe public class IL2Action<T> : IL2Object
    {
        public IL2Action(IntPtr ptr) : base(ptr) { }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass("Action`1", "System").MakeGenericType(new Type[] { typeof(T) });
    }

    unsafe public class IL2Action<T1, T2> : IL2Object
    {
        public IL2Action(IntPtr ptr) : base(ptr) { }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass("Action`2", "System").MakeGenericType(new Type[] { typeof(T1), typeof(T2) });
    }

    unsafe public class IL2Action<T1, T2, T3> : IL2Object
    {
        public IL2Action(IntPtr ptr) : base(ptr) { }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass("Action`3", "System").MakeGenericType(new Type[] { typeof(T1), typeof(T2), typeof(T3) });
    }
    unsafe public class IL2Action<T1, T2, T3, T4> : IL2Object
    {
        public IL2Action(IntPtr ptr) : base(ptr) { }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass("Action`4", "System").MakeGenericType(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });
    }
    unsafe public class IL2Action<T1, T2, T3, T4, T5> : IL2Object
    {
        public IL2Action(IntPtr ptr) : base(ptr) { }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass("Action`5", "System").MakeGenericType(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) });
    }
}