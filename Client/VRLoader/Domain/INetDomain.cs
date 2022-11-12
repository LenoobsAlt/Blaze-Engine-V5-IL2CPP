using System;
using System.Runtime.InteropServices;

namespace VRCLoader.Domain
{
    [ComImport, Guid("E86B87C8-5FC2-442E-A2AB-EAB2E594FEAE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface INetDomain
    {
        void Initialize();
        void OnApplicationStart();
        void MinHook_CreateInstance(IntPtr mVRC_CreateHook, IntPtr mVRC_RemoveHook, IntPtr mVRC_EnableHook, IntPtr mVRC_DisableHook);
    }
}
