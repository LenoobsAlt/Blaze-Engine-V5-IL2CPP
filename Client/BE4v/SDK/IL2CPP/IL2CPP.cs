using System;
using System.Linq;
using System.IO;
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
        AssemblyList = new Dictionary<string, IL2Assembly>();
        foreach (IntPtr assemblyPtr in assembliesarr)
        {
            if (assemblyPtr == IntPtr.Zero)
                continue;

            IntPtr Pointer = Import.Assembly.il2cpp_assembly_get_image(assemblyPtr);
            string AssemblyName = Path.GetFileNameWithoutExtension(Marshal.PtrToStringAnsi(Import.Image.il2cpp_image_get_name(Pointer)));
            if (Limiter.Contains(AssemblyName))
            {
                IL2Assembly assembly = new IL2Assembly(Pointer);
                AssemblyList.Add(AssemblyName, assembly);
                assembly.Name.GreenPrefix("Load Assembly");
            }
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

    private static string[] Limiter = new string[]
    {
        "Assembly-CSharp",
        "Epic.OnlineServices",
        "mscorlib",
        "System",
        "System.Core",
        "VRCCore-Standalone",
        "UnityEngine.CoreModule",
        "UnityEngine.ImageConversionModule",
        "UnityEngine.InputLegacyModule",
        "UnityEngine.UnityAnalyticsModule",
        "UnityEngine.AnimationModule",
        "UnityEngine.PhysicsModule",
        "UnityEngine.UI",
        "UnityEngine.UIModule",
        "UnityEngine.IMGUIModule",
        "UnityEngine.VRModule",
        "Photon-DotNet",
        "VRCSDKBase",
        "VRCSDK2",
        "VRCSDK3",
        "VRCSDK3A",
        "VRC.Udon",
        "VRC.UI.Core",
        "VRC.UI.Elements",
        "VRC.Dynamics",
        "VRC.SDK3.Dynamics.Contact",
        "Facepunch.Steamworks.Win64",
        "Transmtn",
        "Unity.TextMeshPro",
        "DataModel"
    };

    public static Dictionary<string, IL2Assembly> AssemblyList;
}
