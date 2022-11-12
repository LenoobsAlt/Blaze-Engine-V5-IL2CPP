using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using IL2CPP_Core.Objects;

public static class IL2CPP
{
    static IL2CPP()
    {
        domain = Import.Domain.il2cpp_domain_get();

        uint count = 0;
        IntPtr assemblies = Import.Domain.il2cpp_domain_get_assemblies(domain, ref count);
        IntPtr[] assembliesarr = IntPtrToStructureArray<IntPtr>(assemblies, count);
        foreach (IntPtr assemblyPtr in assembliesarr)
        {
            if (assemblyPtr == IntPtr.Zero)
                continue;

            IL2Assembly assembly = new IL2Assembly(Import.Assembly.il2cpp_assembly_get_image(assemblyPtr));
            AssemblyList.Add(assembly.Name, assembly);
        }
    }

    public static T ResolveICall<T>(string signature) where T : Delegate
    {

        var icallPtr = Import.Method.il2cpp_resolve_icall(signature);
        if (icallPtr != IntPtr.Zero)
            return Marshal.GetDelegateForFunctionPointer<T>(icallPtr);
        return null;
    }

    public static T[] IntPtrToStructureArray<T>(IntPtr ptr, uint len)
    {
        IntPtr iter = ptr;
        T[] array = new T[len];
        for (uint i = 0; i < len; i++)
        {
            array[i] = (T)Marshal.PtrToStructure(iter, typeof(T));
            iter += Marshal.SizeOf(typeof(T));
        }
        return array;
    }

    private static IntPtr domain;

    public static Dictionary<string, IL2Assembly> AssemblyList;
}
