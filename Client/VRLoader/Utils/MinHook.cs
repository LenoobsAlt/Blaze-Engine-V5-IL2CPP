using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRCLoader.Utils
{
    public static class MinHook
    {
        // (LPVOID pTarget, LPVOID pDetour, LPVOID* ppOrig)
        public delegate void _VRC_CreateHook(IntPtr pTarget, IntPtr pDetour, out IntPtr ppOrig);
        public delegate void _VRC_RemoveHook(IntPtr pTarget);
        public delegate void _VRC_EnableHook(IntPtr pTarget);
        public delegate void _VRC_DisableHook(IntPtr pTarget);
        public delegate string _CPP2IL_GetString(IntPtr pTarget);
        public delegate IntPtr _GetLicense();

        public static _VRC_CreateHook VRC_CreateHook { get; private set; }
        public static _VRC_RemoveHook VRC_RemoveHook { get; private set; }
        public static _VRC_EnableHook VRC_EnableHook { get; private set; }
        public static _VRC_DisableHook VRC_DisableHook { get; private set; }
        public static _GetLicense GetLicense { get; private set; }

        private static T CreateDelegate<T>(IntPtr method) where T : Delegate
        {
            return Marshal.GetDelegateForFunctionPointer(method, typeof(T)) as T;
        }

        public static void CreateInstance(IntPtr mVRC_CreateHook, IntPtr mVRC_RemoveHook, IntPtr mVRC_EnableHook, IntPtr mVRC_DisableHook)
        {
            VRC_CreateHook = CreateDelegate<_VRC_CreateHook>(mVRC_CreateHook);
            VRC_RemoveHook = CreateDelegate<_VRC_RemoveHook>(mVRC_RemoveHook);
            VRC_EnableHook = CreateDelegate<_VRC_EnableHook>(mVRC_EnableHook);
            VRC_DisableHook = CreateDelegate<_VRC_DisableHook>(mVRC_DisableHook);
        }
    }
}
