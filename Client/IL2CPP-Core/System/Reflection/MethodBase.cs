using System;
using IL2CPP_Core.Objects;

namespace System.Reflection
{
    public class IL2MethodBase : IL2MemberInfo
    {
        public IL2MethodBase(IntPtr ptr) : base(ptr) { }

        /// <summary>
        ///     Not supported IL2CPP
        /// </summary>
        public IL2ParameterInfo[] GetParameters()
        {
            IL2Object result = Instance_Class.GetMethod("GetParameters").Invoke(this);
            if (result == null)
                return null;

            return new IL2Array<IntPtr>(result.Pointer).ToArray<IL2ParameterInfo>();
        }

        /// <summary>
        ///     Not supported IL2CPP
        /// </summary>
        public IL2RuntimeMethodHandle MethodHandle
        {
            get => Instance_Class.GetProperty(nameof(MethodHandle)).GetGetMethod().Invoke(this)?.GetValue<IL2RuntimeMethodHandle>();
        }

        /// <summary>
        ///     Not supported IL2CPP
        /// </summary>
        public IL2MethodBody GetMethodBody()
        {
            return Instance_Class.GetMethod(nameof(GetMethodBody), x => !x.IsStatic).Invoke(this)?.GetValue<IL2MethodBody>();
        }

        unsafe public static IL2MethodBody GetMethodBody(IntPtr handle)
        {
            return Instance_Class.GetMethod(nameof(GetMethodBody), x => x.IsStatic).Invoke(new IntPtr[] { new IntPtr(&handle) })?.GetValue<IL2MethodBody>();
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass(typeof(MethodBase).Name, typeof(MethodBase).Namespace);
    }
}
