using System;
using System.Reflection;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnhollowerBaseLib.Runtime;
using IL2CPP_Core.Objects;

namespace System
{
    public class IL2Delegate : IL2Object
    {
        public IL2Delegate(IntPtr ptr) : base(ptr) { }

        public unsafe static IL2Delegate CreateDelegate(Delegate @delegate, IL2Class klass = null)
        {
            if (@delegate == null)
                return null;

            if (klass == null)
                klass = IL2Action.Instance_Class;

            cache.Add(@delegate);

            var obj = Import.Object.il2cpp_object_new(klass.Pointer);
            var runtimeMethod = Marshal.AllocHGlobal(80);
            try
            {
                MethodInfo methodInfo = @delegate.Method;
                * ((IntPtr*)runtimeMethod) = methodInfo.MethodHandle.GetFunctionPointer();

                // customAttributeIndex : int
                // *((byte*)runtimeMethod + 61) = 0xFF;
                // *((byte*)runtimeMethod + 62) = 0xFF;
                // *((byte*)runtimeMethod + 63) = 0xFF;
                // *((byte*)runtimeMethod + 64) = 0xFF;

                // token : uint
                byte[] tokenByte = BitConverter.GetBytes(@delegate.Method.MetadataToken);
                *((byte*)runtimeMethod + 65) = tokenByte[0];
                *((byte*)runtimeMethod + 66) = tokenByte[1];
                *((byte*)runtimeMethod + 67) = tokenByte[2];
                *((byte*)runtimeMethod + 68) = tokenByte[3];

                // ------------------------------------------------
                // flags : Il2CppMethodFlags : ushort
                Il2CppMethodFlags flags = 0;

                if (methodInfo.IsPrivate)
                    flags |= Il2CppMethodFlags.METHOD_ATTRIBUTE_PRIVATE;
                if (methodInfo.IsFamilyAndAssembly)
                    flags |= Il2CppMethodFlags.METHOD_ATTRIBUTE_FAM_AND_astEM;
                if (methodInfo.IsAssembly)
                    flags |= Il2CppMethodFlags.METHOD_ATTRIBUTE_astEM;
                if (methodInfo.IsFamily)
                    flags |= Il2CppMethodFlags.METHOD_ATTRIBUTE_FAMILY;
                if (methodInfo.IsPublic)
                    flags |= Il2CppMethodFlags.METHOD_ATTRIBUTE_PUBLIC;
                if (methodInfo.IsStatic)
                    flags |= Il2CppMethodFlags.METHOD_ATTRIBUTE_STATIC;
                if (methodInfo.IsFinal)
                    flags |= Il2CppMethodFlags.METHOD_ATTRIBUTE_FINAL;
                if (methodInfo.IsVirtual)
                    flags |= Il2CppMethodFlags.METHOD_ATTRIBUTE_VIRTUAL;
                if (methodInfo.IsHideBySig)
                    flags |= Il2CppMethodFlags.METHOD_ATTRIBUTE_HIDE_BY_SIG;
                if (methodInfo.IsAbstract)
                    flags |= Il2CppMethodFlags.METHOD_ATTRIBUTE_ABSTRACT;
                if (methodInfo.IsSpecialName)
                    flags |= Il2CppMethodFlags.METHOD_ATTRIBUTE_SPECIAL_NAME;

                byte[] flagsByte = BitConverter.GetBytes((ushort)flags);
                *((byte*)runtimeMethod + 69) = flagsByte[0];
                *((byte*)runtimeMethod + 70) = flagsByte[1];

                // ------------------------------------------------
                // iflags : Il2CppMethodImplFlags : ushort
                Il2CppMethodImplFlags iflags = 0;
                var implflag = methodInfo.MethodImplementationFlags;
                if ((implflag & MethodImplAttributes.IL) != 0)
                    iflags |= Il2CppMethodImplFlags.METHOD_IMPL_ATTRIBUTE_IL;
                if ((implflag & MethodImplAttributes.Native) != 0)
                    iflags |= Il2CppMethodImplFlags.METHOD_IMPL_ATTRIBUTE_NATIVE;
                if ((implflag & MethodImplAttributes.OPTIL) != 0)
                    iflags |= Il2CppMethodImplFlags.METHOD_IMPL_ATTRIBUTE_OPTIL;
                if ((implflag & MethodImplAttributes.Runtime) != 0)
                    iflags |= Il2CppMethodImplFlags.METHOD_IMPL_ATTRIBUTE_RUNTIME;
                if ((implflag & MethodImplAttributes.ManagedMask) != 0)
                    iflags |= Il2CppMethodImplFlags.METHOD_IMPL_ATTRIBUTE_MANAGED_MASK;
                if ((implflag & MethodImplAttributes.Unmanaged) != 0)
                    iflags |= Il2CppMethodImplFlags.METHOD_IMPL_ATTRIBUTE_UNMANAGED;
                if ((implflag & MethodImplAttributes.Managed) != 0)
                    iflags |= Il2CppMethodImplFlags.METHOD_IMPL_ATTRIBUTE_MANAGED;
                if ((implflag & MethodImplAttributes.ForwardRef) != 0)
                    iflags |= Il2CppMethodImplFlags.METHOD_IMPL_ATTRIBUTE_FORWARD_REF;
                if ((implflag & MethodImplAttributes.PreserveSig) != 0)
                    iflags |= Il2CppMethodImplFlags.METHOD_IMPL_ATTRIBUTE_PRESERVE_SIG;
                if ((implflag & MethodImplAttributes.InternalCall) != 0)
                    iflags |= Il2CppMethodImplFlags.METHOD_IMPL_ATTRIBUTE_INTERNAL_CALL;
                if ((implflag & MethodImplAttributes.Synchronized) != 0)
                    iflags |= Il2CppMethodImplFlags.METHOD_IMPL_ATTRIBUTE_SYNCHRONIZED;
                if ((implflag & MethodImplAttributes.NoInlining) != 0)
                    iflags |= Il2CppMethodImplFlags.METHOD_IMPL_ATTRIBUTE_NOINLINING;
                if ((implflag & MethodImplAttributes.MaxMethodImplVal) != 0)
                    iflags = Il2CppMethodImplFlags.METHOD_IMPL_ATTRIBUTE_MAX_METHOD_IMPL_VAL;

                byte[] iflagsByte = BitConverter.GetBytes((ushort)iflags);
                *((byte*)runtimeMethod + 71) = iflagsByte[0];
                *((byte*)runtimeMethod + 72) = iflagsByte[1];
                
                // ------------------------------------------------
                // Slot (65535) : ushort
                *((byte*)runtimeMethod + 73) = 0xFF;
                *((byte*)runtimeMethod + 74) = 0xFF;

                // Parameter count : byte
                *((byte*)runtimeMethod + 75) = (byte)methodInfo.GetParameters().Length;

                *((IntPtr*)obj + 2) = methodInfo.MethodHandle.GetFunctionPointer();
                *((IntPtr*)obj + 4) = obj;
                *((IntPtr*)obj + 5) = runtimeMethod;
                *((IntPtr*)obj + 7) = IntPtr.Zero;

                if (obj != IntPtr.Zero)
                    return new IL2Delegate(obj);

            }
            finally
            {
                Marshal.FreeHGlobal(runtimeMethod);
            }
            return null;
        }

        private static readonly List<object> cache = new List<object>();

        unsafe public IntPtr method_ptr
        {
            get => Instance_Class.GetField(nameof(method_ptr)).GetValue<IntPtr>(this).GetValue();
            set => Instance_Class.GetField(nameof(method_ptr)).SetValue(this, new IntPtr(&value));
        }

        unsafe public IntPtr invoke_impl
        {
            get => Instance_Class.GetField(nameof(invoke_impl)).GetValue<IntPtr>(this).GetValue();
            set => Instance_Class.GetField(nameof(invoke_impl)).SetValue(this, new IntPtr(&value));
        }

        public IL2Object m_target
        {
            get => Instance_Class.GetField(nameof(m_target)).GetValue(this);
            set => Instance_Class.GetField(nameof(m_target)).SetValue(this, value == null ? IntPtr.Zero : value.Pointer);
        }

        unsafe public IntPtr method
        {
            get => Instance_Class.GetField(nameof(method)).GetValue<IntPtr>(this).GetValue();
            set => Instance_Class.GetField(nameof(method)).SetValue(this, new IntPtr(&value));
        }

        unsafe public IntPtr delegate_trampoline
        {
            get => Instance_Class.GetField(nameof(delegate_trampoline)).GetValue<IntPtr>(this).GetValue();
            set => Instance_Class.GetField(nameof(delegate_trampoline)).SetValue(this, new IntPtr(&value));
        }

        unsafe public IntPtr extra_arg
        {
            get => Instance_Class.GetField(nameof(extra_arg)).GetValue<IntPtr>(this).GetValue();
            set => Instance_Class.GetField(nameof(extra_arg)).SetValue(this, new IntPtr(&value));
        }

        unsafe public IntPtr method_code
        {
            get => Instance_Class.GetField(nameof(method_code)).GetValue<IntPtr>(this).GetValue();
            set => Instance_Class.GetField(nameof(method_code)).SetValue(this, new IntPtr(&value));
        }

        unsafe public bool method_is_virtual
        {
            get => Instance_Class.GetField(nameof(method_code)).GetValue<bool>(this).GetValue();
            set => Instance_Class.GetField(nameof(method_code)).SetValue(this, new IntPtr(&value));
        }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass(typeof(Delegate).Name, typeof(Delegate).Namespace);
    }
}