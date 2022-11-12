using System;
using IL2CPP_Core.Objects;

namespace System.IO
{
    public class IL2MemoryStream : IL2Stream
    {
        public IL2MemoryStream() : base(IntPtr.Zero)
        {
            Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
            Instance_Class.GetMethod(".ctor").Invoke(Pointer);
        }

        public IL2MemoryStream(byte[] buffer) : base(IntPtr.Zero)
        {
            Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
            int len = buffer.Length;
            IL2Array<byte> array = new IL2Array<byte>(len, IL2Byte.Instance_Class);

            for(int i=0;i<len;i++)
            {
                array[i] = buffer[i];
            }

            Instance_Class.GetMethod(".ctor", x => x.GetParameters().Length == 1 && x.GetParameters()[0].Name == "buffer").Invoke(Pointer, new IntPtr[] { array.Pointer });
        }

        public virtual byte[] ToArray()
        {
            IL2Object result = Instance_Class.GetMethod(nameof(ToArray)).Invoke(this);
            if (result == null) return null;
            return new IL2Array<byte>(result.Pointer).ToArray();
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass(typeof(MemoryStream).Name, typeof(MemoryStream).Namespace);
    }
}
