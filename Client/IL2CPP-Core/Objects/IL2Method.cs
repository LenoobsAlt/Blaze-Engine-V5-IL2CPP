using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace IL2CPP_Core.Objects
{
    public class IL2Method : IL2Object
    {
        internal IL2Method(IntPtr ptr) : base(ptr) { }

        private string szName;
        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(szName))
                    szName = OriginalName;
                return szName;
            }
            set => szName = value;
        }

        public string OriginalName => Marshal.PtrToStringAnsi(Import.Method.il2cpp_method_get_name(Pointer));

        public int Token => Import.Method.il2cpp_method_get_token(Pointer);
        public bool IsAbstract => HasFlag(IL2BindingFlags.METHOD_ABSTRACT);
        public bool IsVirtual => HasFlag(IL2BindingFlags.METHOD_VIRTUAL);
        public bool IsStatic => HasFlag(IL2BindingFlags.METHOD_STATIC);
        public bool IsPrivate => HasFlag(IL2BindingFlags.METHOD_PRIVATE);
        public bool IsPublic => HasFlag(IL2BindingFlags.METHOD_PUBLIC);

        public bool Instance => IsStatic && GetParameters().Length == 0 && ReturnType.Name == ReflectedType.FullName;

        public IL2Class ReflectedType => new IL2Class(Import.Method.il2cpp_method_get_class(Pointer));

        public IL2ClassType ReturnType => new IL2ClassType(Import.Method.il2cpp_method_get_return_type(Pointer));

        public IL2Param[] GetParameters()
        {
            if (Parameters == null)
            {
                Parameters = new List<IL2Param>();
                uint param_count = Import.Method.il2cpp_method_get_param_count(Pointer);
                for (uint i = 0; i < param_count; i++)
                    Parameters.Add(new IL2Param(Import.Method.il2cpp_method_get_param(Pointer, i), Marshal.PtrToStringAnsi(Import.Method.il2cpp_method_get_param_name(Pointer, i))));
            }

            return Parameters.ToArray();
        }
        private List<IL2Param> Parameters = null;


        public bool HasAttribute(IL2Class klass)
        {
            if (klass == null) return false;
            return Import.Method.il2cpp_method_has_attribute(Pointer, klass.Pointer);
        }

        public IL2BindingFlags Flags
        {
            get
            {
                uint f = 0;
                return (IL2BindingFlags)Import.Method.il2cpp_method_get_flags(Pointer, ref f);
            }
        }

        public bool HasFlag(IL2BindingFlags flag) => ((Flags & flag) != 0);

        public IL2Object Invoke() => Invoke(IntPtr.Zero, new IntPtr[] { IntPtr.Zero });
        public IL2Object Invoke(IL2Object obj, bool isVirtual = false, bool ex = true) => Invoke(obj.Pointer, new IntPtr[] { IntPtr.Zero }, isVirtual: isVirtual, ex: ex);
        public IL2Object Invoke(IntPtr obj, bool isVirtual = false, bool ex = true) => Invoke(obj, new IntPtr[] { IntPtr.Zero }, isVirtual: isVirtual, ex: ex);
        public IL2Object Invoke(params IntPtr[] paramtbl)
        {
            return Invoke(IntPtr.Zero, paramtbl);
        }
        public IL2Object Invoke(IL2Object obj, IntPtr[] paramtbl, bool isVirtual = false, bool ex = true) => Invoke(obj.Pointer, paramtbl, isVirtual, ex);
        public IL2Object Invoke(IntPtr obj, IntPtr[] paramtbl, bool isVirtual = false, bool ex = true)
        {
            IntPtr returnval = InvokeMethod(Pointer, obj, paramtbl, isVirtual, ex);
            if (returnval != IntPtr.Zero)
                return new IL2Object(returnval);
            return null;
        }

        public IL2Object<T> Invoke<T>() where T : unmanaged => Invoke<T>(IntPtr.Zero, new IntPtr[] { IntPtr.Zero });
        public IL2Object<T> Invoke<T>(IL2Object obj, bool isVirtual = false, bool ex = true) where T : unmanaged => Invoke<T>(obj.Pointer, new IntPtr[] { IntPtr.Zero }, isVirtual: isVirtual, ex: ex);
        public IL2Object<T> Invoke<T>(IntPtr obj, bool isVirtual = false, bool ex = true) where T : unmanaged => Invoke<T>(obj, new IntPtr[] { IntPtr.Zero }, isVirtual: isVirtual, ex: ex);
        public IL2Object<T> Invoke<T>(params IntPtr[] paramtbl) where T : unmanaged
        {
            return Invoke<T>(IntPtr.Zero, paramtbl);
        }
        public IL2Object<T> Invoke<T>(IL2Object obj, IntPtr[] paramtbl, bool isVirtual = false, bool ex = true) where T : unmanaged => Invoke<T>(obj.Pointer, paramtbl, isVirtual, ex);
        public IL2Object<T> Invoke<T>(IntPtr obj, IntPtr[] paramtbl, bool isVirtual = false, bool ex = true) where T : unmanaged
        {
            IntPtr returnval = InvokeMethod(Pointer, obj, paramtbl, isVirtual, ex);
            if (returnval != IntPtr.Zero)
                return new IL2Object<T>(returnval);
            return null;
        }

        unsafe public static IntPtr InvokeMethod(IntPtr method, IntPtr obj, IntPtr[] paramtbl, bool isVirtual = false, bool ex = true)
        {
            if (method == IntPtr.Zero)
                return IntPtr.Zero;
            IntPtr[] intPtrArray;
            IntPtr returnval = IntPtr.Zero;
            intPtrArray = ((paramtbl != null) ? paramtbl : new IntPtr[0]);
            IntPtr intPtr = Marshal.AllocHGlobal(intPtrArray.Length * sizeof(void*));
            try
            {
                void** pointerArray = (void**)intPtr.ToPointer();
                for (int i = 0; i < intPtrArray.Length; i++)
                    pointerArray[i] = intPtrArray[i].ToPointer();

                IntPtr @m = isVirtual ? Import.Method.il2cpp_object_get_virtual_method(obj, method) : method;

                IntPtr err = IntPtr.Zero;
                returnval = Import.Method.il2cpp_runtime_invoke(@m, obj, pointerArray, new IntPtr(&err));
                if (err != IntPtr.Zero && ex)
                {
                    Console.WriteLine("Error: " + Import.BuildMessage(err));
                    Console.WriteLine("Src: " + new IL2Method(@m).Name);
                }
            }
            finally
            {
                Marshal.FreeHGlobal(intPtr);
            }
            return returnval;
        }
    }
}
