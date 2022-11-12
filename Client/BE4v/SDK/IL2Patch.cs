using System;
using System.Runtime.InteropServices;
using IL2CPP_Core.Objects;
using VRCLoader.Utils;

namespace BE4v.SDK
{
    unsafe public class IL2Patch : IL2Object
    {
        internal IL2Method TargetMethod;
        internal IntPtr OriginalMethod;
        internal IL2Patch(IL2Method targetMethod, Delegate newMethod) : base(IntPtr.Zero)
        {
            Pointer = newMethod.Method.MethodHandle.GetFunctionPointer();
            TargetMethod = targetMethod;
            MinHook.VRC_CreateHook(*(IntPtr*)targetMethod.Pointer, Pointer, out OriginalMethod);
            Enabled = true;
            
            // Import.Patch.VRC_CreateHook(*(IntPtr*)targetMethod.Pointer.ToPointer(), Pointer, out OriginalMethod);
        }
        internal IL2Patch(IntPtr targetMethod, Delegate newMethod) : base(IntPtr.Zero)
        {
            Pointer = newMethod.Method.MethodHandle.GetFunctionPointer();
            TargetMethod = new IL2Method(targetMethod);

            MinHook.VRC_CreateHook(targetMethod, Pointer, out OriginalMethod);
            Enabled = true;
            // Import.Patch.VRC_CreateHook(*(IntPtr*)targetMethod.Pointer.ToPointer(), Pointer, out OriginalMethod);
        }

        public T CreateDelegate<T>() where T : Delegate
        {
            return Marshal.GetDelegateForFunctionPointer(OriginalMethod, typeof(T)) as T;
        }


        public bool Enabled
        {
            get => isEnabled;
            set
            {
                if (isEnabled = value)
                    MinHook.VRC_EnableHook(*(IntPtr*)TargetMethod.Pointer);
                else
                    MinHook.VRC_DisableHook(*(IntPtr*)TargetMethod.Pointer);
            }
        }

        private bool isEnabled = true;
    }
}
