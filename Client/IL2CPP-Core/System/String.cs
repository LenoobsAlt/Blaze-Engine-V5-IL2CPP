using System.Text;
using IL2CPP_Core.Objects;

namespace System
{
    public class IL2String : IL2Object
    {
        public IL2String(IntPtr ptr) : base(ptr) { }
        unsafe public IL2String(string value) : base(IntPtr.Zero)
        {
            if (value == null)
            {
                Pointer = IntPtr.Zero;
                return;
            }

            IL2String result = IL2Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(value));
            if (result == null)
            {
                Pointer = IntPtr.Zero;
                return;
            }
            Pointer = result.Pointer;
        }

        unsafe public override string ToString()
        {
            if (Pointer == IntPtr.Zero)
                return null;

            return new string((char*)Pointer + 10);
        }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass(typeof(string).Name, typeof(string).Namespace);
    }
}
