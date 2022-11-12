using IL2CPP_Core.Objects;

namespace System.Text
{
    public class IL2Encoding : IL2Object
    {
        public IL2Encoding(IntPtr ptr) : base(ptr) { }

        public static IL2Encoding ASCII
        {
            get => Instance_Class.GetProperty(nameof(ASCII)).GetGetMethod().Invoke()?.GetValue<IL2Encoding>();
        }

        public static IL2Encoding UTF8
        {
            get => Instance_Class.GetProperty(nameof(UTF8)).GetGetMethod().Invoke()?.GetValue<IL2Encoding>();
        }

        public IL2String GetString(byte[] bytes)
        {
            IL2Array<byte> array = new IL2Array<byte>(bytes.Length, IL2CPP.AssemblyList["mscorlib"].GetClass("Byte", "System"));
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = bytes[i];
            }
            return GetString(array);
        }
        
        public IL2String GetString(IL2Array<byte> bytes)
        {
            IL2Method method = Instance_Class.GetMethod(nameof(GetString), x => x.GetParameters().Length == 1 && x.GetParameters()[0].Name == "bytes");
            if (method == null)
                return null;

            var result = method.Invoke(this, new IntPtr[] { bytes == null ? IntPtr.Zero : bytes.Pointer });
            if (result == null)
                return null;

            return new IL2String(result.Pointer);
        }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass(typeof(Encoding).Name, typeof(Encoding).Namespace);
    }
}
