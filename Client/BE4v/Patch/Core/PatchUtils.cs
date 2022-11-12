using System;
using BE4v.SDK;
using IL2CPP_Core.Objects;

namespace BE4v.Patch.Core
{
    public static class PatchUtils
    {
        public static T FastPatch<T>(IL2Method method, T newMethod) where T : Delegate
        {
            IL2Patch patch = new IL2Patch(method, newMethod);
            return patch.CreateDelegate<T>();
        }
        public static T FastPatch<T>(IntPtr method, T newMethod) where T : Delegate
        {
            IL2Patch patch = new IL2Patch(method, newMethod);
            return patch.CreateDelegate<T>();
        }
    }
}
