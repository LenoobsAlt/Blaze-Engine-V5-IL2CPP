using System;
using System.IO;
using IL2CPP_Core.Objects;

namespace System.Runtime.Serialization.Formatters.Binary
{
    public sealed class IL2BinaryFormatter : IL2Object
    {
        public IL2BinaryFormatter(IntPtr ptr) : base(ptr) { }

        public IL2BinaryFormatter() : base(IntPtr.Zero)
        {
            Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
            Instance_Class.GetMethod(".ctor", x => x.GetParameters().Length == 0).Invoke(Pointer);
        }

        public void Serialize(IL2Stream serializationStream, IL2Object graph)
        {
            Instance_Class.GetMethod(nameof(Serialize), x => x.GetParameters().Length == 2).Invoke(this, new IntPtr[] { serializationStream == null ? IntPtr.Zero : serializationStream.Pointer, graph == null ? IntPtr.Zero : graph.Pointer });
        }

        public IL2Object Deserialize(IL2Stream serializationStream)
        {
            return Instance_Class.GetMethod(nameof(Deserialize), x => x.GetParameters().Length == 1).Invoke(this, new IntPtr[] { serializationStream.Pointer });
        }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass(typeof(BinaryFormatter).Name, typeof(BinaryFormatter).Namespace);
    }
}
