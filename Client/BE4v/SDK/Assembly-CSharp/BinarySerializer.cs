using System;
using System.Linq;
using BE4v.SDK;
using IL2CPP_Core.Objects;

public class BinarySerializer : IL2Object
{
    static BinarySerializer()
    {
        Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses()
            .FirstOrDefault(x => x.GetNestedTypes()
                .FirstOrDefault(y => y.GetField("SERIALIZABLE_CONTAINER") != null) != null);
    }

    public BinarySerializer(IntPtr ptr) : base(ptr) { }

    unsafe public static IL2Object Deserialize(byte[] bytes)
    {
        IL2Object result = null;

        IL2Method method = Instance_Class.GetMethod(nameof(Deserialize));
        if (method == null)
        {
            (method = Instance_Class.GetMethod(x => x.ReturnType.Name == typeof(bool).FullName
                && x.GetParameters().Length == 2
                && x.GetParameters()[0].ReturnType.Name == typeof(byte[]).FullName
                && x.GetParameters()[1].ReturnType.Name == typeof(object).FullName + "&"
                )
            ).Name = nameof(Deserialize);
            if (method == null)
                return null;

            IntPtr res = IntPtr.Zero;
            int len = bytes.Length;
            IL2Array<byte> array = null;
            if (bytes != null)
            {
                array = new IL2Array<byte>(len, IL2Byte.Instance_Class);
                for (int i = 0; i < len; i++)
                    array[i] = bytes[i];
            }
            method.Invoke(new IntPtr[] { array == null ? IntPtr.Zero : array.Pointer, res });
        }

        return result;
    }


    unsafe public int bytePos
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(bytePos));
            if (field == null)
            {
                (field = Instance_Class.GetField(x => x.ReturnType.Name == typeof(int).FullName)).Name = nameof(bytePos);
                if (field == null)
                    return default;
            }
            return field.GetValue<int>(this).GetValue();
        }
        set
        {
            IL2Field field = Instance_Class.GetField(nameof(bytePos));
            if (field == null)
            {
                (field = Instance_Class.GetField(x => x.ReturnType.Name == typeof(int).FullName)).Name = nameof(bytePos);
                if (field == null)
                    return;
            }
            field.SetValue(this, new IntPtr(&value));
        }
    }

    public IL2Array<byte> decBuffer
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(decBuffer));
            if (field == null)
            {
                (field = Instance_Class.GetField(x => x.ReturnType.Name.StartsWith(typeof(byte).FullName))).Name = nameof(decBuffer);
                if (field == null)
                    return null;
            }
            IL2Object result = field.GetValue(this);
            if (result == null)
                return null;

            return new IL2Array<byte>(result.Pointer);
        }
        set
        {
            IL2Field field = Instance_Class.GetField(nameof(decBuffer));
            if (field == null)
            {
                (field = Instance_Class.GetField(x => x.ReturnType.Name.StartsWith(typeof(byte).FullName))).Name = nameof(decBuffer);
                if (field == null)
                    return;
            }
            field.SetValue(this, value.Pointer);
        }
    }

    private static BinarySerializer serializer
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(serializer));
            if (field == null)
            {
                (field = Instance_Class.GetField(x => x.Instance)).Name = nameof(serializer);
                if (field == null)
                    return null;
            }
            return field.GetValue().GetValue<BinarySerializer>();
        }
        set
        {
            IL2Field field = Instance_Class.GetField(nameof(serializer));
            if (field == null)
            {
                (field = Instance_Class.GetField(x => x.Instance)).Name = nameof(serializer);
                if (field == null)
                    return;
            }
            field.SetValue(value == null ? IntPtr.Zero : value.Pointer);
        }
    }

    public enum TypeCode : byte
	{
		NULL = 1,
		BYTE,
		DOUBLE,
		FLOAT,
		INT,
		SHORT,
		LONG,
		BOOL,
		STRING,
		OBJECT_ARRAY,
		TYPE_ARRAY,
		VECTOR2 = 100,
		VECTOR3,
		VECTOR4,
		QUATERNION,
		COLOR,
		COLOR32,
		EVENTLOG_ENTRY,
		PLAYER_VIDEO_ENTRY,
		STREAM_VIDEO_ENTRY,
		DATA_ELEMENT,
		SERIALIZABLE_BEHAVIOR,
		SERIALIZABLE_CONTAINER,
		GAMEOBJECT,
		TRANSFORM
	}

	public static IL2Class Instance_Class;
}