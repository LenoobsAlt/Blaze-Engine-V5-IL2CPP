using System;
using System.Linq;
using IL2CPP_Core.Objects;

namespace VRC.Core
{
    public static class ParameterSerialization
    {
        static ParameterSerialization()
        {
            Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses()
                .FirstOrDefault(x => x.GetNestedType("SerializableContainer") != null);
        }

        public class SerializableContainer : IL2Object
        {
            public SerializableContainer(IntPtr ptr) : base(ptr) { }

            public string name
            {
                get => Instance_Class.GetField(nameof(name)).GetValue(this)?.GetValue<IL2String>().ToString();
                set => Instance_Class.GetField(nameof(name)).SetValue(this, new IL2String_utf16(value).Pointer);
            }

            public byte[] data
            {
                get
                {
                    IL2Object result = Instance_Class.GetField(nameof(name)).GetValue(this);
                    if (result == null)
                        return null;
                    return new IL2Array<byte>(result.Pointer).GetAsByteArray();
                }
                set
                {
                    IL2Array<byte> array = null;
                    if (value != null)
                    {
                        int len = value.Length;
                        array = new IL2Array<byte>(len, IL2Byte.Instance_Class);
                        for (int i = 0; i < len; i++)
                        {
                            array[i] = value[i];
                        }
                    }
                    Instance_Class.GetField(nameof(name)).SetValue(this, array == null ? IntPtr.Zero : array.Pointer);
                }
            }
        }

        public static IL2Class Instance_Class;
    }
}