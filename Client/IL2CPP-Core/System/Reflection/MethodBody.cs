using System;
using IL2CPP_Core.Objects;

namespace System.Reflection
{
    public class IL2MethodBody : IL2Object
    {
        public IL2MethodBody(IntPtr ptr) : base(ptr) { }

        public byte[] GetILAsByteArray()
        {
            IL2Object result = Instance_Class.GetMethod(nameof(GetILAsByteArray)).Invoke(this);
            if (result == null)
                return null;

            return new IL2Array<byte>(result.Pointer).ToArray();
        }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass(typeof(MethodBody).Name, typeof(MethodBody).Namespace);
    }
}
