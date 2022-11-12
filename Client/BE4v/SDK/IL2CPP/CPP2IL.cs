using System;
using IL2CPP_Core.Objects;

public static class CPP2IL
{
    public static byte[] ToByteArray(IL2Object obj)
    {
        if (obj == null) return null;
        var bf = new System.Runtime.Serialization.Formatters.Binary.IL2BinaryFormatter();
        var ms = new System.IO.IL2MemoryStream();
        bf.Serialize(ms, obj);
        return ms.ToArray();
    }

    public static byte[] ToByteArray(object obj)
    {
        if (obj == null) return null;
        var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        var memoryStream = new System.IO.MemoryStream();
        binaryFormatter.Serialize(memoryStream, obj);
        return memoryStream.ToArray();
    }

    public static T FromByteArray<T>(byte[] data)
    {
        if (data == null) return default(T);
        var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        using (var ms = new System.IO.MemoryStream(data))
        {
            object obj = bf.Deserialize(ms);
            return (T)obj;
        }
    }

    public static T IL2CPPFromByteArray<T>(byte[] data)
    {
        if (data == null) return default(T);
        var bf = new System.Runtime.Serialization.Formatters.Binary.IL2BinaryFormatter();
        var ms = new System.IO.IL2MemoryStream(data);
        object obj = bf.Deserialize(ms);
        return (T)obj;
    }

    public static T FromIL2CPPToManaged<T>(IL2Object obj)
    {
        return FromByteArray<T>(ToByteArray(obj));
    }
}