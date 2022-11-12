using System;
using System.Runtime.InteropServices;

unsafe public static class Import
{
    public unsafe static string BuildMessage(IntPtr exception)
    {
        byte[] ourMessageBytes = new byte[65536];
        fixed (byte* message = &ourMessageBytes[0])
        {
            Import.Exception.il2cpp_format_exception(exception, (void*)message, ourMessageBytes.Length);
            string text = System.Text.Encoding.UTF8.GetString(ourMessageBytes, 0, Array.IndexOf<byte>(ourMessageBytes, 0));
            return text;
        }
    }

    public unsafe static string StringFromNativeUtf8(IntPtr nativeUtf8)
    {
        byte* bytes = (byte*)nativeUtf8.ToPointer();
        int size = 0;
        while (bytes[size] != 0) ++size;
        byte[] buffer = new byte[size];
        Marshal.Copy((IntPtr)nativeUtf8, buffer, 0, size);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }

    public static class Domain
    {
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_domain_get();
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_domain_get_assemblies(IntPtr domain, ref uint count);
    }
        
    public static class Assembly
    {
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_assembly_get_image(IntPtr assembly);
    }

    public static class Image
    {
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_image_get_name(IntPtr image);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static uint il2cpp_image_get_class_count(IntPtr image);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_image_get_class(IntPtr image, uint index);
    }

        
    public static class Handler
    {
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static uint il2cpp_gchandle_new(IntPtr obj, bool pinned);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static void il2cpp_gchandle_free(uint handle);
    }
        
    public static class Exception
    {
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        unsafe public extern static void il2cpp_format_exception(IntPtr exception, void* message, int ourMessageBytes);

    }

    public static class Object
    {
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static string il2cpp_type_get_name(IntPtr type);

        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_object_unbox(IntPtr obj);

        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_method_get_object(IntPtr method);

        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_object_get_class(IntPtr str);

        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_string_new(string str);

            

        [DllImport("GameAssembly", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_string_new_len(string str, int length);

        [DllImport("GameAssembly", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_object_new(IntPtr klass);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_array_new(IntPtr elementTypeInfo, ulong length);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_array_class_get(IntPtr element_class, uint rank);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public extern static int il2cpp_array_length(IntPtr pArray);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public extern static uint il2cpp_array_get_byte_length(IntPtr pArray);
    }

    public static class Class
    {
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_class_get_name(IntPtr klass);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_class_get_namespace(IntPtr method);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static uint il2cpp_class_get_flags(IntPtr klass, ref uint flags);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_class_get_methods(IntPtr klass, ref IntPtr iter);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_class_get_method_from_name(IntPtr klass, IntPtr name, int argsCount);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_class_get_fields(IntPtr klass, ref IntPtr iter);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_class_get_nested_types(IntPtr klass, ref IntPtr iter);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_class_get_properties(IntPtr klass, ref IntPtr iter);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_class_get_interfaces(IntPtr klass, ref IntPtr iter);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_class_get_type(IntPtr klass);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_type_get_object(IntPtr type);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_class_get_parent(IntPtr type);

        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_class_from_system_type(IntPtr type);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_class_get_image(IntPtr klass);

        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_class_get_declaring_type(IntPtr klass);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static bool il2cpp_class_has_attribute(IntPtr klass, IntPtr attr_class);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static bool il2cpp_class_is_enum(IntPtr klass);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static int il2cpp_class_get_type_token(IntPtr method);
    }

    public static class Property
    {
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_property_get_name(IntPtr property);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static uint il2cpp_property_get_flags(IntPtr property);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_property_get_get_method(IntPtr property);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_property_get_set_method(IntPtr property);
    }

    public static class Method
    {
        [DllImport("GameAssembly", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_resolve_icall([MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_method_get_name(IntPtr method);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_method_get_return_type(IntPtr method);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static uint il2cpp_method_get_flags(IntPtr method, ref uint flags);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static uint il2cpp_method_get_param_count(IntPtr method);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_method_get_param(IntPtr method, uint index);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_method_get_param_name(IntPtr method, uint index);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static int il2cpp_method_get_token(IntPtr method);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static bool il2cpp_method_has_attribute(IntPtr method, IntPtr attr_class);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_method_get_class(IntPtr method);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        unsafe public extern static IntPtr il2cpp_runtime_invoke(IntPtr method, IntPtr obj, void** param, IntPtr exc);

        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_object_get_virtual_method(IntPtr obj, IntPtr method);

    }

    public static class Field
    {
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_field_get_name(IntPtr field);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static uint il2cpp_field_get_flags(IntPtr field, ref uint flags);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_field_get_type(IntPtr field);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static IntPtr il2cpp_field_get_parent(IntPtr field);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        unsafe public extern static IntPtr il2cpp_field_get_value_object(IntPtr field, IntPtr obj);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        unsafe public extern static void il2cpp_field_static_set_value(IntPtr field, IntPtr value);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        unsafe public extern static void il2cpp_field_set_value(IntPtr obj, IntPtr field, IntPtr value);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static int il2cpp_field_get_offset(IntPtr field);
        [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static bool il2cpp_field_has_attribute(IntPtr field, IntPtr attr_class);
    }

    public static class Patch
    {
        [DllImport("winmm", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static void VRC_CreateHook(IntPtr pTarget, IntPtr pDetour, out IntPtr ppOrig);

        [DllImport("winmm", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static void VRC_RemoveHook(IntPtr pTarget);

        [DllImport("winmm", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static void VRC_EnableHook(IntPtr pTarget);

        [DllImport("winmm", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static void VRC_DisableHook(IntPtr pTarget);
    }
}


public enum IL2BindingFlags
{
    VISIBILITY_MASK = 0x00000007,
    ACCESS_MASK = 0x0007,

    // Types
    TYPE_NOT_PUBLIC = 0x00000000,
    TYPE_PUBLIC = 0x00000001,
    TYPE_NESTED_PUBLIC = 0x00000002,
    TYPE_NESTED_PRIVATE = 0x00000003,
    TYPE_NESTED_FAMILY = 0x00000004,
    TYPE_NESTED_ASSEMBLY = 0x00000005,
    TYPE_NESTED_FAM_AND_ASSEM = 0x00000006,
    TYPE_NESTED_FAM_OR_ASSEM = 0x00000007,
    TYPE_LAYOUT_MASK = 0x00000018,
    TYPE_AUTO_LAYOUT = 0x00000000,
    TYPE_SEQUENTIAL_LAYOUT = 0x00000008,
    TYPE_EXPLICIT_LAYOUT = 0x00000010,
    TYPE_CLASS_SEMANTIC_MASK = 0x00000020,
    TYPE_CLASS = 0x00000000,
    TYPE_INTERFACE = 0x00000020,
    TYPE_ABSTRACT = 0x00000080,
    TYPE_SEALED = 0x00000100,
    TYPE_SPECIAL_NAME = 0x00000400,
    TYPE_IMPORT = 0x00001000,
    TYPE_SERIALIZABLE = 0x00002000,
    TYPE_WINDOWS_RUNTIME = 0x00004000,
    TYPE_STRING_FORMAT_MASK = 0x00030000,
    TYPE_ANSI_CLASS = 0x00000000,
    TYPE_UNICODE_CLASS = 0x00010000,
    TYPE_AUTO_CLASS = 0x00020000,
    TYPE_BEFORE_FIELD_INIT = 0x00100000,
    TYPE_FORWARDER = 0x00200000,
    TYPE_RESERVED_MASK = 0x00040800,
    TYPE_RT_SPECIAL_NAME = 0x00000800,
    TYPE_HAS_SECURITY = 0x00040000,

    // Methods
    METHOD_COMPILER_CONTROLLED = 0x0000,
    METHOD_PRIVATE = 0x0001,
    METHOD_FAM_AND_ASSEM = 0x0002,
    METHOD_ASSEM = 0x0003,
    METHOD_FAMILY = 0x0004,
    METHOD_FAM_OR_ASSEM = 0x0005,
    METHOD_PUBLIC = 0x0006,
    METHOD_STATIC = 0x0010,
    METHOD_FINAL = 0x0020,
    METHOD_VIRTUAL = 0x0040,
    METHOD_HIDE_BY_SIG = 0x0080,
    METHOD_VTABLE_LAYOUT_MASK = 0x0100,
    METHOD_REUSE_SLOT = 0x0000,
    METHOD_NEW_SLOT = 0x0100,
    METHOD_STRICT = 0x0200,
    METHOD_ABSTRACT = 0x0400,
    METHOD_SPECIAL_NAME = 0x0800,
    METHOD_PINVOKE_IMPL = 0x2000,
    METHOD_UNMANAGED_EXPORT = 0x0008,
    METHOD_RESERVED_MASK = 0xd000,
    METHOD_RT_SPECIAL_NAME = 0x1000,
    METHOD_HAS_SECURITY = 0x4000,
    METHOD_REQUIRE_SEC_OBJECT = 0x8000,

    // Fields
    FIELD_COMPILER_CONTROLLED = 0x0000,
    FIELD_PRIVATE = 0x0001,
    FIELD_FAM_AND_ASSEM = 0x0002,
    FIELD_ASSEMBLY = 0x0003,
    FIELD_FAMILY = 0x0004,
    FIELD_FAM_OR_ASSEM = 0x0005,
    FIELD_PUBLIC = 0x0006,
    FIELD_STATIC = 0x0010,
    FIELD_INIT_ONLY = 0x0020,
    FIELD_LITERAL = 0x0040,
    FIELD_NOT_SERIALIZED = 0x0080,
    FIELD_SPECIAL_NAME = 0x0200,
    FIELD_PINVOKE_IMPL = 0x2000,
    FIELD_RESERVED_MASK = 0x9500,
    FIELD_RT_SPECIAL_NAME = 0x0400,
    FIELD_HAS_FIELD_MARSHAL = 0x1000,
    FIELD_HAS_DEFAULT = 0x8000,
    FIELD_HAS_FIELD_RVA = 0x0100,
}