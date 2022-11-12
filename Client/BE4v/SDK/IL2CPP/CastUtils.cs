using System;
using System.Linq;
using IL2CPP_Core.Objects;

public static class CastUtils
{
    public static IntPtr IL2Typeof(this Type type)
    {
        IL2Class ilType = null;

        ilType = IL2CPP.AssemblyList["mscorlib"].GetClass(type.Name, type.Namespace);
        if (ilType == null)
            ilType = (IL2Class)type.GetFields().First(x => x.IsStatic && x.FieldType == typeof(IL2Class)).GetValue(null);

        return IL2Typeof(ilType);
    }

    unsafe public static IntPtr IL2Typeof(this IL2Class type)
    {
        IntPtr ptr = Import.Class.il2cpp_class_get_type(type.Pointer);
        if (ptr == IntPtr.Zero)
            return IntPtr.Zero;

        IntPtr result = Import.Class.il2cpp_type_get_object(ptr);
        if (result == IntPtr.Zero)
            return IntPtr.Zero;

        return result;
    }
}
