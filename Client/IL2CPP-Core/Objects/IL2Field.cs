using System;
using System.Runtime.InteropServices;

namespace IL2CPP_Core.Objects
{
    public class IL2Field : IL2Object
    {
        internal IL2Field(IntPtr ptr) : base(ptr) { }

        private string szName;
        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(szName))
                    szName = Marshal.PtrToStringAnsi(Import.Field.il2cpp_field_get_name(Pointer));
                return szName;
            }
            set => szName = value;
        }

        public IL2ClassType ReturnType => new IL2ClassType(Import.Field.il2cpp_field_get_type(Pointer));
        public int Token => Import.Field.il2cpp_field_get_offset(Pointer);

        public IL2BindingFlags Flags
        {
            get
            {
                uint flags = 0;
                return (IL2BindingFlags)Import.Field.il2cpp_field_get_flags(Pointer, ref flags);
            }
        }
        public bool HasFlag(IL2BindingFlags flag) => ((Flags & flag) != 0);

        public bool IsStatic => HasFlag(IL2BindingFlags.FIELD_STATIC);
        public bool IsPrivate => HasFlag(IL2BindingFlags.FIELD_PRIVATE);
        public bool IsPublic => HasFlag(IL2BindingFlags.FIELD_PUBLIC);

        public bool Instance => IsStatic && ReturnType.Name == ReflectedType.FullName;
        public IL2Class ReflectedType => new IL2Class(Import.Field.il2cpp_field_get_parent(Pointer));

        public bool HasAttribute(IL2Class klass)
        {
            if (klass == null) return false;
            return Import.Field.il2cpp_field_has_attribute(Pointer, klass.Pointer);
        }

        public IL2Object GetValue() => GetValue(IntPtr.Zero);
        public IL2Object GetValue(IL2Object obj) => GetValue(obj.Pointer);
        public IL2Object GetValue(IntPtr obj)
        {
            IntPtr returnval = IntPtr.Zero;
            if (HasFlag(IL2BindingFlags.FIELD_STATIC))
                returnval = Import.Field.il2cpp_field_get_value_object(Pointer, IntPtr.Zero);
            else
                returnval = Import.Field.il2cpp_field_get_value_object(Pointer, obj);
            if (returnval != IntPtr.Zero)
                return new IL2Object(returnval);
            return null;
        }
        public new IL2Object<T> GetValue<T>() where T : unmanaged => GetValue<T>(IntPtr.Zero);
        public IL2Object<T> GetValue<T>(IL2Object obj) where T : unmanaged => GetValue<T>(obj.Pointer);
        public IL2Object<T> GetValue<T>(IntPtr obj) where T : unmanaged
        {
            IntPtr returnval = IntPtr.Zero;
            if (HasFlag(IL2BindingFlags.FIELD_STATIC))
                returnval = Import.Field.il2cpp_field_get_value_object(Pointer, IntPtr.Zero);
            else
                returnval = Import.Field.il2cpp_field_get_value_object(Pointer, obj);
            if (returnval != IntPtr.Zero)
                return new IL2Object<T>(returnval);
            return null;
        }
        public void SetValue(IL2Object value) => SetValue(IntPtr.Zero, value.Pointer);
        public void SetValue(IntPtr value) => SetValue(IntPtr.Zero, value);
        public void SetValue(IL2Object obj, IntPtr value) => SetValue(obj.Pointer, value);
        public void SetValue(IntPtr obj, IntPtr value)
        {
            if (HasFlag(IL2BindingFlags.FIELD_STATIC))
                Import.Field.il2cpp_field_static_set_value(Pointer, value);
            else
                Import.Field.il2cpp_field_set_value(obj, Pointer, value);
        }
    }
}
