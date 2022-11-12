using System.Text;
using IL2CPP_Core.Objects;

namespace System
{
    public class IL2String : IL2Object
    {
        public IL2String(IntPtr ptr) : base(ptr) { }

        unsafe public override string ToString()
        {
            if (Pointer == IntPtr.Zero)
                return null;

            return new string((char*)Pointer + 10);
        }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass(typeof(string).Name, typeof(string).Namespace);
    }

    public class IL2String_utf8 : IL2String
    {
        public IL2String_utf8(IntPtr ptr) : base(ptr) { }
        unsafe public IL2String_utf8(string value) : base(IntPtr.Zero)
        {
            if (value == null)
            {
                Pointer = IntPtr.Zero;
                return;
            }
            Pointer = Import.Object.il2cpp_string_new(value);
        }

        public static new IL2Class Instance_Class = IL2String.Instance_Class;
    }

    public class IL2String_utf16 : IL2String
    {
        public IL2String_utf16(IntPtr ptr) : base(ptr) { }
        unsafe public IL2String_utf16(string value) : base(IntPtr.Zero)
        {
            Pointer = IntPtr.Zero;
            if (value == null) return;
            while (Pointer == IntPtr.Zero || ToString() != value)
            {
                int length = value.Length;
                Pointer = Import.Object.il2cpp_string_new(string.Empty.PadRight(length, '\u0001'));
                for (int i = 0; i < length; i++)
                {
                    *(char*)(Pointer + 0x14 + (0x2 * i)) = value[i];
                }
            }
        }

        public static new IL2Class Instance_Class = IL2String.Instance_Class;
    }
}
