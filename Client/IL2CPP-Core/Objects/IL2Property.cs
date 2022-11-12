using System;
using System.Runtime.InteropServices;

namespace IL2CPP_Core.Objects
{
    public class IL2Property : IL2Object
    {
        internal IL2Property(IntPtr ptr) : base(ptr) { }

        private string szName;
        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(szName))
                    szName = Marshal.PtrToStringAnsi(Import.Property.il2cpp_property_get_name(Pointer));
                return szName;
            }
            set
            {
                szName = value;
                if (GetGetMethod() != null)
                    GetGetMethod().Name = "get_" + value;
                if (GetSetMethod() != null)
                    GetSetMethod().Name = "set_" + value;
            }
        }

        public IL2BindingFlags Flags => (IL2BindingFlags)Import.Property.il2cpp_property_get_flags(Pointer);
        public bool HasFlag(IL2BindingFlags flag) => ((Flags & flag) != 0);
        public bool Instance => GetGetMethod() != null && GetGetMethod().Instance;

        public IL2Method GetGetMethod()
        {
            if (getMethod == null)
            {
                IntPtr method = Import.Property.il2cpp_property_get_get_method(Pointer);
                if (method != IntPtr.Zero)
                    getMethod = new IL2Method(method);
            }
            return getMethod;
        }
        private IL2Method getMethod;
        public IL2Method GetSetMethod()
        {
            if (setMethod == null)
            {
                IntPtr method = Import.Property.il2cpp_property_get_set_method(Pointer);
                if (method != IntPtr.Zero)
                    setMethod = new IL2Method(method);
            }
            return setMethod;
        }
        private IL2Method setMethod;

        public bool IsStatic => GetGetMethod()?.IsStatic == true || GetSetMethod()?.IsStatic == true;
        public bool IsPublic => GetGetMethod()?.IsPublic == true || GetSetMethod()?.IsPublic == true;
    }
}
